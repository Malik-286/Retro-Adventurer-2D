using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TimerPanel : MonoBehaviour
{

    [SerializeField] TextMeshProUGUI timeText;
    [SerializeField] float levelCompletionTime;
    [SerializeField] float levelStartupTime;
    [SerializeField] GameObject timeEndPanel;
 

    PlayerHealth playerHealth;
    public bool isTimeCompleted = false;

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
            isTimeCompleted = true;
            Debug.Log("You Run Out of Time");
            timeText.text = ("00:00");
            Time.timeScale = 0.0f;
            PlayerHealth playerHealth = FindObjectOfType<PlayerHealth>();
            playerHealth.enabled = false;
         }

    }


    public void RestTime()
    {
        levelCompletionTime = 0;
        Time.timeScale = 1.0f;
        levelCompletionTime = levelStartupTime;
    }

    
}
