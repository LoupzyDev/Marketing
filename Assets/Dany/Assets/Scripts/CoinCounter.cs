using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinCounter : MonoBehaviour
{
    [SerializeField] int coins;
    [SerializeField] int coinValue;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            coins += coinValue;
            //destruir monedas 
            //Destroy(collision.gameObject);
            Destroy(this.gameObject);
        }
    }
}
