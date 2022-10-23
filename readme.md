# Cheems

## PENGELOLAAN EKSPEDISI CHEEMS

### Anggota Kelompok :

- 1119002 - Albertus Angkuw
- 1119004 - Calvin Jeremy
- 1119006 - William Juniar
- 1119028 - Aji Parama
- 1119038 - Elangel Neilea

## Tools, Library, and Framework

### Bahasa Pemrograman

- [Go Language](https://golang.org/)
  <br>
  Go is an open source programming language that makes it easy to build simple, reliable, and efficient software

### Dukungan Framework

- [Vue.js](https://vuejs.org/)
  <br>
  Vue.js is a progressive, incrementally-adoptable JavaScript framework for building UI on the web
- [Fiber](https://docs.gofiber.io/)
  <br>
  Fiber is an Express inspired web framework built on top of Fasthttp, the fastest HTTP engine for Go. Designed to ease things up for fast development with zero memory allocation and performance in mind.

### Dukungan Template

- [ArchitectUI](https://demo.dashboardpack.com/architectui-vue-free/#/)
  <br>
  ArchitectUI is one of the most popular admin dashboard templates ever released. It is used by

<br>

## GIT (Version Control)

#### Mengatur Username & Email

```
git config --global user.name "Adi Budi "
git config --global user.email "adibudi@gmail.com"
* Cara diatas untuk mengatur disemua repositori, untuk spesifik hilangkan "--global"
```

#### Cara Clone Lokal Git

```
git clone git@github.com:albertusangkuw/MamangForce.git
```

#### Push

```
git add .
git commit -m "Your messages"
git push -u origin main
```

Jika terjadi error seperti ini :

```
To git@github.com:albertusangkuw/MamangForce.git
 ! [rejected]        main -> main (non-fast-forward)
error: failed to push some refs to 'git@github.com:albertusangkuw/MamangForce.git'
hint: Updates were rejected because the tip of your current branch is behind
hint: its remote counterpart. Integrate the remote changes (e.g.
hint: 'git pull ...') before pushing again.
hint: See the 'Note about fast-forwards' in 'git push --help' for details.
```

Maka selesaikan dengan :

```
git pull origin main
git push -u origin main
```

Jika masih terjadi error ketika pull origin main :
Maka cari file yang konflik kemudian edit pilih yang bermasalah
Kemudian jalankan

```
git add .
git commit -m "Merge to ..isi command..."
git push -u origin main
```

#### Pull

```
git pull origin main
```

#### Remove

```
git rm file --> file is your file name
            --> and then, use PUSH
```

#### Show Config

```
git config --list
```

#### Remove A Commit That Already Pushed

1. `git log` to find out the commit you want to revert
2. `git push origin +7f6d03:master` while `7f6d03` is the commit before the wrongly pushed commit. + was for force push

#### Merging without Auto-Merge

1. `git merge --no-commit --no-ff <local-branch>`
2. `git reset HEAD`
3. To see all diff: `git diff`
