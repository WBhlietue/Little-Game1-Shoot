using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameStart : MonoBehaviour
{
    public Image A;

    public float time;
    public float TargetTime;
    float speed;
    int a = 1;
    public AudioSource Audio;
    void Start()
    {
        if (!PlayerPrefs.HasKey("first"))
        {
            PlayerPrefs.SetInt("first", 1);
            PlayerPrefs.SetFloat("music", 1);
            PlayerPrefs.SetFloat("sound", 1);
        }
        speed = 1f / time;
    }
    void Update()
    {
        switch (a)
        {
            case 0:
               // Audio.Play();
                TargetTime -= Time.deltaTime;
                if (TargetTime <= 0)
                {
                    a = -1;
                }
                break;
            case 1:
                A.color -= new Color(0, 0, 0, speed * Time.deltaTime);
                if (A.color.a <= 0)
                {
                    a = 0;
                }
                break;
            case -1:
                A.color += new Color(0, 0, 0, speed * Time.deltaTime);
                if (A.color.a >= 1)
                {
                    UnityEngine.SceneManagement.SceneManager.LoadScene("Menu");
                }
                break;
        }
    }
}