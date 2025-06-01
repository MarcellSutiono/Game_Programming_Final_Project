using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class Sun : MonoBehaviour
{
    [SerializeField] private Light2D globalLight;
    private PlayerData pd;

    private void Start()
    {
        pd = PlayerData.getInstance();
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
            globalLight.intensity = 0.8f;
            pd.PlayerPow += 4f;
            pd.IsSun = true;
        }
    }
}
