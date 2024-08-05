using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TimerPanel : MonoBehaviour
{

    public static TimerPanel Instance;

    [SerializeField] TextMeshProUGUI timeText;
    [SerializeField] float levelCompletionTime;
    [SerializeField] float levelStartupTime;
    [SerializeField] GameObject timeEndPanel;
    [SerializeField] TextMeshProUGUI keyPickupText;


    PlayerHealth playerHealth;
    public bool isTimeCompleted = false;
    KeyPickup keyPickup;

    private void Awake()
    {
        if (Instance==null)
        {
            Instance = this;
        }
    }
    void Start()
    {
        levelStartupTime = levelCompletionTime;
        playerHealth = FindObjectOfType<PlayerHealth>();
        keyPickup = FindObjectOfType<KeyPickup>();
 
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

         if(keyPickup != null)
        {
            if(keyPickup.isKeyCollected == true)
            {
                keyPickupText.text = "1";
            }
            else if (keyPickup.isKeyCollected == false)
            {
                keyPickupText.text = "0";
            }         
        }

    }


    public void RestTime()
    {
        levelCompletionTime = 0;
        Time.timeScale = 1.0f;
        levelCompletionTime = levelStartupTime;
    }

    public void ResetTime()
    {
        levelCompletionTime += 30;
        isTimeCompleted = false;
        Time.timeScale = 1.0f;
        PlayerHealth playerHealth = FindObjectOfType<PlayerHealth>();
        playerHealth.enabled = true;
    }
}
