using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CoinCounter : MonoBehaviour
{
    [SerializeField] int coins;
    [SerializeField] int coinValue;
    [SerializeField] TextMeshProUGUI coinsText;

    [SerializeField] CarController carController;

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
            StartCoroutine(DoubleSpeed());

        }

        if (collision.gameObject.CompareTag("DeathZone"))
        {
            SceneManager.LoadScene("Game");
        }
    }
    private IEnumerator DoubleSpeed() {
        float originalSpeed = carController.speed;
        float originalCarSpeed = carController.carSpeed;


        carController.speed = Mathf.Min(carController.speed * 2, 160);
        carController.carSpeed = Mathf.Min(carController.carSpeed * 2, 80);

        yield return new WaitForSeconds(2);


        carController.speed = 80;
        carController.carSpeed = 40;
    }
}
