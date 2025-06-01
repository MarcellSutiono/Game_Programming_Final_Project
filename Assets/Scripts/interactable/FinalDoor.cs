using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalDoor : MonoBehaviour
{
    [SerializeField] private Transform dest;
    [SerializeField] private GameObject player;
    [SerializeField] private Sprite insertedDoor;

    private PlayerData pd;
    private bool isOpen = false;
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

    void Start()
    {
        pd = PlayerData.getInstance();
    }

    // Update is called once per frame
    void Update()
    {
        if (inRange && (pd.RedGem && pd.BlueGem && pd.OrangeGem && pd.WhiteGem) && Input.GetKeyDown(KeyCode.F))
        {
            GetComponent<SpriteRenderer>().sprite = insertedDoor;
            if (!isOpen)
            {
                isOpen = true;
                return;
            }
            else
            {
                player.transform.position = dest.position;
            }
        }
    }
}
