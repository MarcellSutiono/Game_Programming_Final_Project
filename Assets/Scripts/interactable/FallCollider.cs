using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallCollider : MonoBehaviour
{
    [SerializeField] GameObject gameOver;

    private void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log("Jatoh");
        if(col.gameObject.CompareTag("Player"))
        {
            Time.timeScale = 0f;
            gameOver.SetActive(true);
        }
    }
}
