using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BlackMoku : MonoBehaviour
{

    public Image A;
    public float speed;
    public string B;
    void Update()
    {
        A.color += new Color(0, 0, 0, speed / 255f);
        if (A.color.a >= 1)
        {
            Switch();
        }
    }
    public void SwitchScene(string Name)
    {
        Time.timeScale = 1;
        B = Name;
        A.gameObject.SetActive(true);
        this.enabled = true;
    }
    public void Switch()
    {
        SceneManager.LoadScene(B);
    }
}
