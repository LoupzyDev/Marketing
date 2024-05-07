using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField] float timer;
    [SerializeField] TextMeshProUGUI timerText;

    void Start()
    {

    }

    void Update()
    {
        timer -= Time.deltaTime; 

        if(timer <= 0)
        {
            Time.timeScale = 0;
        }

        UpdateTimerDisplay();
    }

    void UpdateTimerDisplay()
    {
        if (timerText != null)
        {
            timerText.text = "Time: " + Mathf.RoundToInt(timer).ToString();
        }
    }

}
