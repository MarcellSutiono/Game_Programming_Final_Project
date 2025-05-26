using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GemCollect : MonoBehaviour
{
    [SerializeField] private Image currGem;
    [SerializeField] private string color;
    private PlayerData pd;

    private void Start()
    {
        pd = PlayerData.getInstance();
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            if (color == "red")
            {
                pd.RedGem = true;
                Destroy(gameObject);
            }
            else if(color == "blue")
            {
                pd.BlueGem = true;
            }

            currGem.color = Color.white;
        }
    }
}
