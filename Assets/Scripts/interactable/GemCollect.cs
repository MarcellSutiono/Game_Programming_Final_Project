using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GemCollect : MonoBehaviour
{
    [SerializeField] private GameObject lightGem;
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
                Destroy (gameObject);
            }
            else if(color == "orange")
            {
                pd.OrangeGem = true;
                Destroy(gameObject);
            }
            else if(color == "white")
            {
                pd.WhiteGem = true;
                Destroy(gameObject);
            }

            Destroy(lightGem);
            currGem.color = Color.white;
        }
    }
}
