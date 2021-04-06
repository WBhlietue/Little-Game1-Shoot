using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundValue : MonoBehaviour
{
    public AudioSource Audio;
    public string Name;
    void Start()
    {
        Audio.volume = PlayerPrefs.GetFloat(Name);
    }
    public void Change(Slider B)
    {
        PlayerPrefs.SetFloat(Name, B.value);
        Audio.volume = B.value;
    }
}
