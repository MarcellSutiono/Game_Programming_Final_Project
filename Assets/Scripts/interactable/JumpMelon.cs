using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpMelon : MonoBehaviour
{
    private PlayerData pd;
    private bool canCollect = false;
    private GameSound gs;

    private void Start()
    {
        pd = PlayerData.getInstance();
        StartCoroutine(collectable());
        gs = FindObjectOfType<GameSound>();
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.CompareTag("Player") && canCollect)
        {
            if(col.gameObject.CompareTag("Hat"))
            {
                return;
            }
            else
            {
                gs.PlaySFX(gs.jumpMelon);
                Destroy(gameObject);
                pd.JumpPower += 1.5f;
                pd.Score += 200;
            }
        }
    }

    IEnumerator collectable()
    {
        yield return new WaitForSeconds(1f);
        canCollect = true;
    }
}
