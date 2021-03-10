using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRePos : MonoBehaviour
{
    public GameObject Player;
    public float Pad;
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Player.transform.position += new Vector3(Pad, 0, 0);
        }
    }
}
