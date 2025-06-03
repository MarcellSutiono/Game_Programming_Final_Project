using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Game : MonoBehaviour
{
    public void exitGame()
    {
        PlayerPrefs.DeleteAll();
        SceneManager.LoadScene(0);
    }

    public void exitAndSave()
    {
        PlayerPrefs.SetInt("score", PlayerData.getInstance().Score);
        SceneManager.LoadScene(0);
    }
}
