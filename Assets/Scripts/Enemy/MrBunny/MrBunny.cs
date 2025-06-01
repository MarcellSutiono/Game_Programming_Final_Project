using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MrBunny : MonoBehaviour
{
    [SerializeField] private GameObject textDamage;
    [SerializeField] private GameObject jumpMelon;

    private PlayerData pd;
    [SerializeField] private float entityHp;

    void Start()
    {
        pd = PlayerData.getInstance();
    }

    void Update()
    {
        if (entityHp <= 0)
        {
            GameObject jm =  Instantiate(jumpMelon, transform.position, Quaternion.identity);
            Rigidbody2D jmRB = jm.GetComponent<Rigidbody2D>();

            if(jmRB != null)
            {
                Vector2 force = new Vector2(1f, 5f);
                jmRB.AddForce(force * 100);
            }

            Destroy(gameObject);
            pd.Score += 1000;
        }
    }
    private void OnCollisionEnter2D(Collision2D col)
    {
        if(col.collider.CompareTag("Hat"))
        {
            GameObject dmg = Instantiate(textDamage, transform.position, Quaternion.identity);
            dmg.GetComponent<TextMeshPro>().text = pd.PlayerPow.ToString();
            entityHp -= pd.PlayerPow;
        }
    }

    public void sunDamage()
    {
        float totalDmg = (pd.PlayerPow * 5f);
        entityHp -= totalDmg;
        GameObject dmg = Instantiate(textDamage, transform.position, Quaternion.identity);
        dmg.GetComponent<TextMeshPro>().text = totalDmg.ToString();
    }
}
