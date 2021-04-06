using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;

public class ClickEvent : MonoBehaviour, IPointerClickHandler
{
    public ClickToFunction A;


    public void OnPointerClick(PointerEventData eventData)
    {
        A.Invoke("click");
    }

}
[System.Serializable]
public class ClickToFunction : UnityEvent<string> { }
