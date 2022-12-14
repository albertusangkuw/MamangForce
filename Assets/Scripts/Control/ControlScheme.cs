using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlScheme : MonoBehaviour
{
    public KeyCode right = KeyCode.RightArrow;
    public KeyCode left = KeyCode.LeftArrow;
    public KeyCode jump = KeyCode.UpArrow;

    public KeyCode mainGun = KeyCode.X;

    public KeyCode specialGun = KeyCode.Z;

    private PlayerController player;

    public float fireRate = 0.15F;

    public float climbRate = 0.15F;
    private float nextFire = 0.0F;
    private float climbFire = 0.0F;

    public bool isControl = true;
    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<PlayerController>();
        isControl = !player.type.Equals(PlayerType.Prisoner);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!isControl)
        {
            return;
        }
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            SceneChanger.ChangeScene("Pause");
            return;
        }
        if (Input.GetKey(KeyCode.X) && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            player.ShootMainGun();
        }
        if (Input.GetKey(KeyCode.Z) && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            player.ShootSpecialGun();
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            player.Backward();
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            player.Forward();
        }

        if ((Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.DownArrow)) && Time.time > climbFire)
        {
            climbFire = Time.time + climbRate;
            player.Climb(Input.GetAxisRaw("Vertical"));
        }
        else if (Input.GetKey(KeyCode.Space))
        {
            player.Jump();
        }

        if (Input.GetKeyUp(KeyCode.LeftArrow))
        {
            player.Stop();
        }
        if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            player.Stop();
        }
    }
}
