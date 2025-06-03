using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FinalScore : MonoBehaviour
{
    private PlayerData pd;
    private TextMeshProUGUI scoreText;
    void Start()
    {
        pd = PlayerData.getInstance();
        scoreText = GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {
        scoreText.text = "Final Score : " + pd.Score.ToString(); 
    }
}
