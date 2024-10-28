using Platformer;
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
        StartCoroutine(PassPlayerHealthRefrence());
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
            int maxHealth = playerHealth.GetMaxHealth();
            int heartCount = heartImages.Length;

            // Calculate the health per heart segment
            float healthPerHeart = maxHealth / (float)heartCount;

            for (int i = 0; i < heartCount; i++)
            {
                // Determine the threshold for each heart to be active or inactive
                if (currentHealth > i * healthPerHeart)
                {
                    heartImages[i].SetActive(true);
                }
                else
                {
                    heartImages[i].SetActive(false);
                }
            }
        }
    }

    IEnumerator PassPlayerHealthRefrence()
    {
        yield return new WaitForSeconds(0.1f);
        playerHealth = FindObjectOfType<PlayerHealth>();
          if (playerHealth == null)
        {
            Debug.LogError("Player Controller not found in the scene.");
        }
    }



}


