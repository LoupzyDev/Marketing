using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CoinCounter : MonoBehaviour
{
    [SerializeField] int coins;
    [SerializeField] int coinValue;
    [SerializeField] TextMeshProUGUI coinsText;

    private void Update()
    {
        coinsText.text = "Coins: " + Mathf.RoundToInt(coins).ToString();

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Coin"))
        {
            coins += coinValue;
            //destruir monedas 
            //Destroy(collision.gameObject);
            collision.gameObject.SetActive(false);
            
        }
    }
}
