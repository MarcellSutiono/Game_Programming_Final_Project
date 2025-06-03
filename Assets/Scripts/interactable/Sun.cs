using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class Sun : MonoBehaviour
{
    [SerializeField] private Light2D globalLight;
    private PlayerData pd;
    private GameSound gs;

    private void Start()
    {
        pd = PlayerData.getInstance();
        gs = FindObjectOfType<GameSound>();
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.CompareTag("Player"))
        {
            gs.PlaySFX(gs.theSun);
            Destroy(gameObject);
            globalLight.intensity = 0.8f;
            pd.PlayerPow += 4f;
            pd.IsSun = true;
            PlayerPrefs.SetInt("sun", 1);
            pd.Score += 2000;
        }
    }
}
