using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BlackMokuOver : MonoBehaviour
{
    public List<GameObject> Objects = new List<GameObject>();
    public float speed;
    public Image A;

    void Update()
    {
        A.color -= new Color(0, 0, 0, speed / 255f);
        if (A.color.a <= 0)
        {
            foreach (var i in Objects)
            {
                i.SetActive(true);
            }
            A.gameObject.SetActive(false);
            Destroy(this);
        }
    }
}
