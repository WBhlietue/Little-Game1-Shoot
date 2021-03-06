using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Move : MonoBehaviour
{
    public float speed;
    public GameObject Bullet;
    public GManager A;
    public GameObject Player;
    public GameObject Centerplayer;
    public Text Blt;
    public Color Bonus;
    public Color Nobonus;
    public float minrot;
    public float maxrot;
    public BlackMoku B;

    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.A))
        {
            if (transform.eulerAngles.z <= 90 || transform.eulerAngles.z >= 270)
            {
                transform.eulerAngles -= new Vector3(0, 0, speed);
            }

        }
        if (Input.GetKey(KeyCode.D))
        {
            if (transform.eulerAngles.z <= 90 || transform.eulerAngles.z >= 270)
            {
                transform.eulerAngles += new Vector3(0, 0, speed);
            }
        }
        if (transform.eulerAngles.z > 90 && transform.eulerAngles.z < 180)
        {
            transform.eulerAngles = new Vector3(0, 0, 90);
        }
        if (transform.eulerAngles.z < 270 && transform.eulerAngles.z > 180)
        {
            transform.eulerAngles = new Vector3(0, 0, 270);
        }
    }
    public bool canshoot = true;
    public bool ItemUsed = false;
    public float Targettime;
    public Transform[] Sups;
    float count = 0;
    public bool ItemMegaShoot = false;
    private void Update()
    {
        if (!ItemUsed)
        {
            if (Input.GetKeyDown(KeyCode.Space) && canshoot)
            {
                if (A.BulletNum > 0)
                {
                    A.bulletbonus = 1.0f;
                    A.BulletNum--;
                    if (!ItemMegaShoot)
                    {
                        Instantiate(Bullet, Centerplayer.transform.position, this.transform.rotation);
                    }
                    else
                    {
                        foreach (var i in Sups)
                        {
                            Instantiate(Bullet, i.position, i.rotation);
                        }
                    }
                    canshoot = false;
                    if (A.BulletNum == 0)
                    {
                        this.GetComponent<ReloadBullet>().ST();
                        A.bulletbonus = 2.2f;

                    }
                    if (A.BulletNum == 1)
                    {
                        Blt.color = Bonus;
                    }
                }
                Blt.text = A.BulletNum + "/" + A.MaxBullet;
            }
        }
        else
        {

            if (Input.GetKey(KeyCode.Space))
            {
                count += Time.deltaTime;
                if (count >= Targettime)
                {
                    if (A.BulletNum > 0)
                    {
                        A.bulletbonus = 1.0f;
                        A.BulletNum--;
                        if (!ItemMegaShoot)
                        {
                            Instantiate(Bullet, Centerplayer.transform.position, this.transform.rotation);
                        }
                        else
                        {
                            foreach (var i in Sups)
                            {
                                Instantiate(Bullet, i.position, i.rotation);
                            }
                        }
                        if (A.BulletNum == 0)
                        {
                            this.GetComponent<ReloadBullet>().ST();
                            A.bulletbonus = 2.2f;

                        }
                        if (A.BulletNum == 1)
                        {
                            Blt.color = Bonus;
                        }
                    }
                    Blt.text = A.BulletNum + "/" + A.MaxBullet;
                    count = 0;
                }
            }
        }

    }
}
