using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthPanel : MonoBehaviour
{

    [SerializeField] GameObject[] heartImages;
    PlayerHealth playerHealth;


     void Start()
    {
        playerHealth = FindObjectOfType<PlayerHealth>();
    }

    void Update()
    {
        UpdateHeartIcon();
    }


    void UpdateHeartIcon()
    {
        if (playerHealth == null)
        {
            return;
        }
            
        float currentHealth = playerHealth.GetCurrentHealth();

        if (currentHealth == 75f)
        {
            heartImages[3].SetActive(false);
        }
        else if (currentHealth == 50f  )
        {
            heartImages[2].SetActive(false);
        }
        else if (currentHealth == 25f)
        {
            heartImages[1].SetActive(false);
        }
        else if(currentHealth <= 0)
        {
            heartImages[0].SetActive(false);
        }
    }
}
