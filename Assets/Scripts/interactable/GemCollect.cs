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
    private GameSound gs;

    private void Start()
    {
        pd = PlayerData.getInstance();
        gs = FindObjectOfType<GameSound>();
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            gs.PlaySFX(gs.gemCollect);
            if (color == "red")
            {
                pd.RedGem = true;
                pd.Score += 500;
                PlayerPrefs.SetInt("red", 1);
                Destroy(gameObject);
            }
            else if(color == "blue")
            {
                pd.BlueGem = true;
                pd.Score += 500;
                PlayerPrefs.SetInt("blue", 1);
                Destroy (gameObject);
            }
            else if(color == "orange")
            {
                pd.OrangeGem = true;
                pd.Score += 500;
                PlayerPrefs.SetInt("orange", 1);
                Destroy(gameObject);
            }
            else if(color == "white")
            {
                pd.WhiteGem = true;
                pd.Score += 500;
                PlayerPrefs.SetInt("white", 1);
                Destroy(gameObject);
            }

            Destroy(lightGem);
            currGem.color = Color.white;
        }
    }
}
