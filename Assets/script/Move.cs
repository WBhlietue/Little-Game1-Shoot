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
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && canshoot)
        {
            if (A.BulletNum > 0)
            {
                A.bulletbonus = 1.0f;
                A.BulletNum--;
                Instantiate(Bullet, Centerplayer.transform.position, this.transform.rotation);
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
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }
}
