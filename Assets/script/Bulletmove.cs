using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bulletmove : MonoBehaviour
{
    public float speed;
    public GManager A;
    int x = 0;
    private void Start()
    {
        A = GetComponent<GetGameManager>().Get();
        this.transform.localScale = A.Tomruulah;
    }
    void FixedUpdate()
    {
        transform.Translate(Vector2.down * speed * Time.fixedDeltaTime);
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("wall"))
        {
            if (speed > 0)
            {
                other.gameObject.GetComponent<Resetcanshoot>().Res();
            }
            Destroy(this.gameObject);
        }
        else if (other.gameObject.CompareTag("bullet"))
        {
            if (other.gameObject.GetComponent<Bulletmove>().speed < 0)
            {
                Destroy(other.gameObject);
            }
        }
        else if (other.gameObject.CompareTag("Player"))
        {
            if (speed < 0)
            {
                A.HpChange(1);
                Destroy(this.gameObject);
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("enemy"))
        {
            if (speed > 0)
            {
                if (other.gameObject.GetComponent<EnemyMove>().ItemNum == 0)
                {
                    x++;
                    Destroy(other.gameObject);
                    A.Hit(other.gameObject.GetComponent<EnemyMove>().score, x);
                }
                else
                {
                    A.GetItem(other.gameObject.GetComponent<EnemyMove>().ItemNum);
                    Destroy(other.gameObject);
                }

            }
        }
        else if (other.gameObject.CompareTag("bee"))
        {
            if (speed > 0)
            {
                A.Hit(other.gameObject.GetComponent<EnemyMove>().score, x);
                Destroy(other.gameObject);
                //A.HpChange(-1);
                A.gameTime += 10;
            }
        }
    }
}
