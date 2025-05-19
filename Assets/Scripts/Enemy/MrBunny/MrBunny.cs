using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MrBunny : MonoBehaviour
{
    [SerializeField] private GameObject textDamage;
    private int level = 5;
    private int entityHp;

    void Start()
    {
        entityHp = level * 10;
    }

    void Update()
    {
        if (entityHp <= 0)
        {
            Destroy(gameObject);
        }
    }
    private void OnCollisionEnter2D(Collision2D col)
    {
        if(col.collider.CompareTag("Hat"))
        {
            Instantiate(textDamage, transform.position, Quaternion.identity);
            entityHp -= 10;
        }
    }
}
