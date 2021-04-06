using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemTime : MonoBehaviour
{
    public float time;
    public float count1 = 0;
    public float count2 = 0;
    public float count3 = 0;
    public GManager A;
    public bool item1 = false;
    public bool item2 = false;
    public bool item3 = false;
    private void FixedUpdate()
    {
        if (item1)
        {
            count1 += Time.fixedDeltaTime;
            if (count1 >= time)
            {
                A.ItemOver(1);
                item1 = false;
                count1 = 0;
            }
        }
        if (item2)
        {
            count2 += Time.fixedDeltaTime;
            if (count2 >= time)
            {
                A.ItemOver(2);
                count2 = 0;
                item2 = false;
            }
        }
        if (item3)
        {
            count3 += Time.fixedDeltaTime;
            if (count3 >= time)
            {
                A.ItemOver(3);
                count3 = 0;
                item3 = false;
            }
        }
        if (!item1 && !item2 && !item3)
        {
            this.enabled = false;
        }
    }
}
