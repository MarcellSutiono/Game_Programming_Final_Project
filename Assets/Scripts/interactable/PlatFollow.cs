using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatFollow : MonoBehaviour
{
    [SerializeField] private GameObject player;
    private void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.CompareTag("Player"))
        {
            player.transform.SetParent(gameObject.transform);
        }
    }

    private void OnCollisionExit2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            player.transform.SetParent(null);
        }
    }
}
