using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    public float speed;
    int a = 1;
    public GameObject Bullet;
    GManager A;
    void Start()
    {
        if (transform.position.x > 0)
        {

            GetComponent<SpriteRenderer>().flipX = true;
            a = -1;
        }
        A = GetComponent<GetGameManager>().Get();
    }
    public float targettime;
    public int score;
    float count = 0;
    public bool isbee;
    void FixedUpdate()
    {
        /* if (!isbee)
         {
             count += Time.fixedDeltaTime;
             if (count >= targettime)
             {
                 count = 0;
                 Instantiate(Bullet, this.transform.position, this.transform.rotation);
             }
         }*/
        transform.Translate(Vector2.right * a * speed * Time.fixedDeltaTime * A.timebonus);

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("wall"))
        {
            Destroy(this.gameObject);
        }
    }
}
