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
    [SerializeField] private GameObject pauseMenu;

    [SerializeField] private GameObject redGO;
    [SerializeField] private GameObject blueGO;
    [SerializeField] private GameObject orangeGO;
    [SerializeField] private GameObject whiteGO;

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
            Destroy(redGO);
            red.color = Color.white;
        }
        else if (pd.BlueGem)
        {
            Destroy(blueGO);
            blue.color = Color.white;
        }
        else if (pd.OrangeGem)
        {
            Destroy(orangeGO);
            orange.color = Color.white;
        }
        else if (pd.WhiteGem)
        {
            Destroy(whiteGO);
            white.color = Color.white;
        }

        if(Input.GetKeyDown(KeyCode.Escape))
        {
            pauseGame();
        }
    }

    private void pauseGame()
    {
        pauseMenu.SetActive(!pauseMenu.activeSelf);

        if (pauseMenu.activeSelf)
        {
            Time.timeScale = 0f;
        }
        else
        {
            Time.timeScale = 1f;
        }
    }
}
