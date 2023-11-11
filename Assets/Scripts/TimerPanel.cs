using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TimerPanel : MonoBehaviour
{

    [SerializeField] TextMeshProUGUI timeText;
    [SerializeField] float levelCompletionTime;
    [SerializeField] float levelStartupTime;


    PlayerHealth playerHealth;

      void Start()
    {
        levelStartupTime = levelCompletionTime;
        playerHealth = FindObjectOfType<PlayerHealth>();

    }
    void Update()
    {
        levelCompletionTime -= Time.smoothDeltaTime;
        timeText.text = levelCompletionTime.ToString("00:00");
        if (levelCompletionTime <= 0.0f)
        {
            Debug.Log("You Run Out of Time");
            timeText.text =("00:00");

            PlayerHealth playerHealth = FindObjectOfType<PlayerHealth>();
            playerHealth.isAlive = false;
            Time.timeScale = 1.0f;
        }

    }


    public void RestTime()
    {
        levelCompletionTime = 0;
        Time.timeScale = 1.0f;
        levelCompletionTime = levelStartupTime;
    }

    
}
