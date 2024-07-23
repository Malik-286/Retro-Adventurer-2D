using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SafeZonePickup : MonoBehaviour
{


     PlayerHealth playerHealth;
    bool isActive = true;

    void OnEnable()
    {
        if (playerHealth == null)
        {
            playerHealth = GetComponentInParent<PlayerHealth>();

            if (playerHealth == null)
            {
                Debug.LogError("PlayerHealth component not found in parent!");
                return;
            }
        }

        if (isActive)
        {
            playerHealth.enabled = false;
            StartCoroutine(SafeZoneRoutine());
        }
    }


    IEnumerator SafeZoneRoutine()
    {
        isActive = false;
        yield return new WaitForSeconds(15);
        playerHealth.enabled = true;

        yield return new WaitForSeconds(1f);
        gameObject.SetActive(false);
        isActive = true; // Reset isActive so it can be picked up again
    }
}
