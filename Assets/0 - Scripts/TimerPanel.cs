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
 

    PlayerHealth playerHealth;
    public bool isTimeCompleted = false;
    KeyPickup keyPickUp;
    [SerializeField] TextMeshProUGUI keyPickUpText;


      void Awake()
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
         keyPickUp = FindObjectOfType<KeyPickup>();
  
    }
    void Update()
    {
        UpdateKeyStatus();
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

    public void ResetTime()
    {
        levelCompletionTime += 30;
        isTimeCompleted = false;
        Time.timeScale = 1.0f;
        PlayerHealth playerHealth = FindObjectOfType<PlayerHealth>();
        playerHealth.enabled = true;
    }


    void UpdateKeyStatus()
    {
       
        if(keyPickUp != null)
        {
            if(keyPickUp.isKeyCollected == false)
            {
                keyPickUpText.text = "0";
            }else if (keyPickUp.isKeyCollected == true)
            {
                keyPickUpText.text = "1";
             }
             
        }
    }



}
