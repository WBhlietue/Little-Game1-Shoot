using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GManager : MonoBehaviour
{
    public Transform[] POSS;
    public float time;
    public float score;
    float count = 0;
    public Text A;
    public int BulletNum;
    public int MaxBullet;
    public int HP;
    public Text HPT;
    public GameObject OverP;
    public GameObject ClearP;
    public List<int> randomnums = new List<int>();
    List<int> onehundrednums = new List<int>();
    List<int> onehundrednums2 = new List<int>();
    List<int> Monsterspawn = new List<int>();
    public float timebonus = 1.0f;
    public float bulletbonus = 1.0f;
    public List<Monsters> Mon = new List<Monsters>();
    void Start()
    {
        for (int i = 0; i < 100; i++)
        {
            onehundrednums.Add(i);
            onehundrednums2.Add(i);
        }
        while (onehundrednums.Count > 0)
        {
            int a = Random.Range(0, onehundrednums.Count);
            randomnums.Add(onehundrednums[a]);
            onehundrednums.RemoveAt(a);
        }
        while (onehundrednums2.Count > 0)
        {
            int a = Random.Range(0, onehundrednums2.Count);
            Monsterspawn.Add(onehundrednums2[a]);
            onehundrednums2.RemoveAt(a);
        }
        Time.timeScale = 1;
        A.text = score.ToString();
    }

    void Update()
    {
        count += Time.deltaTime;
        if (count >= time)
        {
            Monsters N = Mon[SpawnEnemy()];
            Instantiate(N.Enemy, N.Pos[Random.Range(0, N.Pos.Length)].transform.position, this.transform.rotation);
            count = 0;
        }
    }
    bool bee = false;
    int SpawnEnemy()
    {
        if (!bee)
        {
            int x = 10;
            int b = Random.Range(0, 100);
            for (int i = 0; i < x; i++)
            {
                if (i == b)
                {

                    bee = true;
                    return 0;
                }
            }
            x += 3;
            return AAAA();
        }
        int n = Random.Range(0, 1000);
        int m = Random.Range(0, 1000);
        if (n == m)
        {
            return 0;
        }
        return AAAA();
    }
    int AAAA()
    {
        int a = Random.Range(0, Monsterspawn.Count);
        int b = 0;
        for (int i = 0; i < Monsterspawn.Count; i++)
        {
            if (a == Monsterspawn[i])
            {
                b = i;
            }
        }
        int c = 0;
        for (int i = 1; i < Mon.Count; i++)
        {
            c += Mon[i].a;
            if (b < c)
            {
                c = i;
                break;
            }
        }
        return c;

    }
    public float gameTime;
    public Text GameTimeTXT;
    public Color textx;
    private void FixedUpdate()
    {
        gameTime -= Time.fixedDeltaTime;
        string a = ((int)gameTime / 60 < 10) ? "0" + (int)gameTime / 60 : "" + (int)gameTime / 60;
        string b = ((int)gameTime % 60 < 10) ? "0" + (int)gameTime % 60 : "" + (int)gameTime % 60;
        GameTimeTXT.text = a + ":" + b;
        if (gameTime <= 0)
        {
            Clear();
        }
        if (gameTime <= 20 && timebonus == 1.0f)
        {
            timebonus = 2.0f;
            GameTimeTXT.color = textx;
        }
    }
    public void Hit(int a, int b)
    {
        float c;
        switch (b)
        {
            case 1:
                a *= 1;
                break;
            case 2:
                c = a * 2.2f;
                a = (int)c;
                break;
            case 3:
                c = a * 3.8f;
                a = (int)c;
                break;
            case 4:
                c = a * 5.2f;
                a = (int)c;
                break;
            case 5:
                c = a * 6.6f;
                a = (int)c;
                break;
            case 6:
                c = a * 10f;
                a = (int)c;
                break;
        }
        c = score + (a * bulletbonus * timebonus);
        score = (int)c;
        A.text = score.ToString();

    }
    public void Over()
    {
        Time.timeScale = 0;
        OverP.SetActive(true);
    }
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void Clear()
    {
        Time.timeScale = 0;
        ClearP.SetActive(true);
    }
    public void HpChange(int a)
    {
        HP -= a;
        HPT.text = "HP: " + HP;
        if (HP <= 0)
        {
            Over();
        }
    }
}

[System.Serializable]
public class Monsters
{
    public GameObject Enemy;
    public int a;
    public GameObject[] Pos;
}
