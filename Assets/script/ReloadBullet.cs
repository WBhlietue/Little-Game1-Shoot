using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReloadBullet : MonoBehaviour
{

    Move A;
    public Image B;
    private void Start()
    {
        A = GetComponent<Move>();
    }
    public float targettime;
    float count = 0;
    public void ST(){
        this.enabled = true;
        B.gameObject.SetActive(true);
    }
    void Update()
    {
        count += Time.deltaTime;
        B.fillAmount = (float)(count / targettime);
        if (count >= targettime)
        {
            count = 0;
            A.A.BulletNum = A.A.MaxBullet;
            A.Blt.text = A.A.BulletNum + "/" + A.A.MaxBullet;
            this.enabled = false;
            A.Blt.color = A.Nobonus;
            B.gameObject.SetActive(false);
        }
    }
}
