using System.Collections;
using System.Collections.Generic;
using Unity.Cinemachine;
using UnityEngine;

public class SetAnimatedTarget : MonoBehaviour
{
    PlayerController playerController;
    Animator animatedTargetAnimator;

       CinemachineStateDrivenCamera cinemachineStateDrivenCamera;

    void Start()
    {
         cinemachineStateDrivenCamera = GetComponent<CinemachineStateDrivenCamera>();

        // Start the coroutine to pass the player controller reference
         StartCoroutine(PassPlayerControllerReference());
    }

    IEnumerator PassPlayerControllerReference()
    {
        yield return new WaitForSeconds(1f);
        playerController = FindObjectOfType<PlayerController>();

        if (playerController != null)
        {
            // Set the follow target to the player controller's transform
            if (cinemachineStateDrivenCamera != null)
            {
                 cinemachineStateDrivenCamera.Follow = playerController.transform;
                cinemachineStateDrivenCamera.LayerIndex = 7;
            }
            else
            {
                Debug.LogError("CinemachineStateDrivenCamera component not found on the GameObject.");
            }

            // Get the Animator component from the player controller
            animatedTargetAnimator = playerController.GetComponent<Animator>();
            if (animatedTargetAnimator != null)
            {
                // Set the animated target of the Cinemachine camera
                 cinemachineStateDrivenCamera.AnimatedTarget = animatedTargetAnimator;
            }
            else
            {
                Debug.LogError("Animator component not found on the PlayerController's GameObject.");
            }
        }
        else
        {
            Debug.LogError("PlayerController not found in the scene.");
        }
    }


  
}
