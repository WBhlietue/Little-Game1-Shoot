using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetValue : MonoBehaviour
{
    public string Name;
    void Start()
    {
        GetComponent<UnityEngine.UI.Slider>().value = PlayerPrefs.GetFloat("music");
        Destroy(this);
    }

}
