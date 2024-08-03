using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThingToFollow : MonoBehaviour
{

    PlayerController playerController;

 
    void Start()
    {
        StartCoroutine(PassPlayerControllerRefrence());
        
    }

    void Update()
    {
        if (playerController != null)
        {
          gameObject.transform.position = playerController.transform.position;
        }
    }

    IEnumerator PassPlayerControllerRefrence()
    {
        yield return new WaitForSeconds(0.1f);
        playerController = FindObjectOfType<PlayerController>();
        if (playerController == null)
        {
            Debug.LogError("Player Controller not found in the scene.");
        }
    }
     
}
