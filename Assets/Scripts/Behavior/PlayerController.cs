using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PlayerType
{
    Playable,
    Prisoner,
    Soldier,
    Boss,
    UnLabeled
}
public enum PlayerState
{
    Idle,
    Walk,
    Jump,
    Shoot,
    Dead
}
public class PlayerController : MonoBehaviour
{
    public PlayerType type = PlayerType.UnLabeled;
    public GameObject mainBullet;
    public GameObject specialBullet;
    public float moveSpeed = 30;
    public float jumpSpeed = 600;
    public Vector2 maxVelocity = new Vector2(9, 5);

    public float specialGunAmmo = 4;
    public float specialGunBurst = 4;
    public float health = 100;
    public bool isPause = false;
    

    protected bool isOnGround = false;
    protected bool isFacingForward = true;
    protected bool isLadder;
    protected bool isClimbing;
    protected bool isDead = false;
    
    protected int currentState = (int)PlayerState.Idle;
    protected Animator animationComponent;
    protected Rigidbody2D rigidComponent;

    protected float speed = 5f;
    protected float defaultGravityScale;
    protected float originalMoveSpeed;

    // Start is called before the first frame update
    void Start()
    {
        rigidComponent = GetComponent<Rigidbody2D>();
        animationComponent = GetComponent<Animator>();
        originalMoveSpeed = moveSpeed;
        defaultGravityScale = rigidComponent.gravityScale;
    }

    void LateUpdate()
    {
        animationComponent.SetFloat("Speed", Mathf.Abs(rigidComponent.velocity.x));
        Debug.Log(((PlayerState)currentState).ToString() + " ; " + isOnGround + ";" + rigidComponent.velocity.x + "u/s");
        if(isPause || isDead){
            rigidComponent.bodyType = RigidbodyType2D.Static;
            return;
        }else{
            rigidComponent.bodyType = RigidbodyType2D.Dynamic;
        }
        if (health <= 0)
        {
            currentState = (int)PlayerState.Dead;
            if (isDead){
                return;
            }
            rigidComponent.bodyType = RigidbodyType2D.Static;
            type = PlayerType.UnLabeled;
            transform.Rotate(transform.eulerAngles.x, transform.eulerAngles.y, 90, Space.Self);
            isDead = true;
            Destroy(gameObject, 1);
        }
    }
    public void Forward()
    {
        if (Mathf.Abs(rigidComponent.velocity.x) > maxVelocity.x)
        {
            return;
        }
        currentState = (int)PlayerState.Walk;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
        rigidComponent.AddForce(Vector2.right * moveSpeed);
        isFacingForward = true;
    }

    public void Backward()
    {
        if (Mathf.Abs(rigidComponent.velocity.x) > maxVelocity.x)
        {
            return;
        }
        currentState = (int)PlayerState.Walk;
        transform.rotation = Quaternion.Euler(new Vector3(0, 180, 0));
        rigidComponent.AddForce(Vector2.left * moveSpeed);
        isFacingForward = false;
    }

    public void Stop()
    {
        rigidComponent.velocity.Set(0, 0);
    }

    public void Jump()
    {
        if (!isOnGround || rigidComponent.velocity[1] > maxVelocity.y)
        {
            return;
        }
        rigidComponent.AddForce(Vector2.up * jumpSpeed);
        currentState = (int)PlayerState.Jump;
        isOnGround = false;
    }

    public void Climb(float verticalAxisRaw)
    {
        float speed = 40f;
        if (isLadder)
        {
            rigidComponent.velocity = new Vector2(0, 0);
            rigidComponent.gravityScale = 0f;
            transform.Translate(Vector2.up * verticalAxisRaw * speed * Time.deltaTime);
        }
    }

    public void ShootMainGun()
    {
        if (currentState == (int)PlayerState.Shoot)
        {
            return;
        }
        currentState = (int)PlayerState.Shoot;

        Quaternion rotation = Quaternion.Euler(new Vector3(0, 0, 0));
        Vector2 vDirection = Vector2.right;
        if (!isFacingForward)
        {
            rotation = Quaternion.Euler(new Vector3(0, 180, 0));
            vDirection = Vector2.left;
        }
        Transform gunPoint = gameObject.transform.GetChild(1);
        GameObject bulletIntance = Instantiate(mainBullet, gunPoint.position, rotation);
        Bullet b = bulletIntance.GetComponent<Bullet>();
        b.whiteList = gameObject;
        b.direction = vDirection;
        currentState = (int)PlayerState.Idle;
    }

    public void ShootSpecialGun()
    {
        if (specialGunAmmo <= 0 || specialGunBurst <= 0)
        {
            return;
        }
        specialGunAmmo--;
        currentState = (int)PlayerState.Shoot;

        Transform gunPoint = gameObject.transform.GetChild(1);

        Vector3 degreeRotation = new Vector3(0, 0, 0);
        Vector2 vDirection = Vector2.right;
        if (!isFacingForward)
        {
            degreeRotation = new Vector3(0, 180, 0);
            vDirection = Vector2.left;
        }
        for (int i = 0; i < specialGunBurst; i++)
        {
            Quaternion rotation = Quaternion.Euler(degreeRotation.x, degreeRotation.y, Random.Range(-4f, 4f));
            GameObject bulletIntance = Instantiate(specialBullet, gunPoint.position, rotation);
            Bullet b = bulletIntance.GetComponent<Bullet>();
            b.whiteList = gameObject;
            b.direction = vDirection;
        }
        currentState = (int)PlayerState.Idle;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(isPause){
            return;
        }
        // Check Ground
        if (other.CompareTag("Object"))
        {
            currentState = (int)PlayerState.Idle;
            isOnGround = true;
        }
        // Check Bullet Hit
        if (other.CompareTag("Bullet"))
        {
            var b = other.GetComponent<Bullet>();
            if (b.whiteList != gameObject)
            {
                health -= b.damage;
            }
        }
        // Check if Out of Space Limit
        if (other.CompareTag("SpaceLimit"))
        {
            health = 0;
        }

        // Check Ladder
        if (other.CompareTag("Ladder"))
        {
            isLadder = true;
            Debug.Log("Ladder is True");
        }
        // Check is Prisoner
        if (other.CompareTag("Player"))
        {
            var anotherPlayer = other.GetComponent<PlayerController>();
            if (anotherPlayer.type.Equals(PlayerType.Prisoner))
            {
                GamePlay.Instance.playerPrefab = other.gameObject;
                GamePlay.Instance.livesPlayer += 1;
                GamePlay.Instance.changeTargetCamera(0,other.gameObject);
                other.GetComponent<ControlScheme>().isControl = true;
                Destroy(gameObject);
            }
        }

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if(isPause){
            return;
        }
        if (collision.CompareTag("Ladder"))
        {
            isLadder = false;
            rigidComponent.gravityScale = defaultGravityScale;
            Debug.Log("Ladder is False");
        }
    }


    public PlayerState GetCurrentState()
    {
        return (PlayerState)currentState;
    }
    public bool GetIsDead()
    {
        return isDead;
    }

}
