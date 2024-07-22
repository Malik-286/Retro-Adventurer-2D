using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthPanel : MonoBehaviour
{

    public  GameObject[] heartImages;
    PlayerHealth playerHealth;


     void Start()
    {
        playerHealth = FindObjectOfType<PlayerHealth>();
    }

    void Update()
    {
        UpdateHeartIcon();
    }


    public void UpdateHeartIcon()
    {
        if (playerHealth != null)
        {
            float currentHealth = playerHealth.GetCurrentHealth();

            if (currentHealth >= 100f)
            { 
               for(int i = 0; i < heartImages.Length; i++)
                {
                    heartImages[i].SetActive(true);
                }
            }
            else if (currentHealth == 75f)
            {
                heartImages[3].SetActive(false);
                heartImages[2].SetActive(true);

            }
            else if (currentHealth == 50f)
            {
                 heartImages[2].SetActive(false);
                 heartImages[1].SetActive(true);


            }
            else if (currentHealth == 25f)
            {
                 heartImages[1].SetActive(false);
                 heartImages[0].SetActive(true);


            }
            else if (currentHealth <= 0)
            {
                heartImages[0].SetActive(false);

            }
        }
                   
    }

    
}


