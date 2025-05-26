using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaveDoor : MonoBehaviour
{
    [SerializeField] private Transform dest;
    [SerializeField] private GameObject player;

    private bool inRange = false;

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            inRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            inRange = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(inRange && Input.GetKeyDown(KeyCode.F))
        {
            player.transform.position = dest.position;
        }
    }
}
