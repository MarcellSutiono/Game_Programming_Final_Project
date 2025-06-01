using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    private PlayerData pd;

    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private Image red;
    [SerializeField] private Image blue;
    [SerializeField] private Image orange;
    [SerializeField] private Image white;

    private void Start()
    {
        pd = PlayerData.getInstance();
        pd.Score = PlayerPrefs.GetInt("score");

        if (PlayerPrefs.GetInt("red") == 1)
        {
            pd.RedGem = true;
        }
        else if (PlayerPrefs.GetInt("blue") == 1)
        {
            pd.BlueGem = true;
        }
        else if (PlayerPrefs.GetInt("orange") == 1)
        {
            pd.OrangeGem = true;
        }
        else if (PlayerPrefs.GetInt("white") == 1)
        {
            pd.WhiteGem = true;
        }
    }
    private void Update()
    {
        scoreText.text = pd.Score.ToString();

        if (pd.RedGem)
        {
            red.color = Color.white;
        }
        else if (pd.BlueGem)
        {
            blue.color = Color.white;
        }
        else if (pd.OrangeGem)
        {
            orange.color = Color.white;
        }
        else if (pd.WhiteGem)
        {
            white.color = Color.white;
        }
    }
}
