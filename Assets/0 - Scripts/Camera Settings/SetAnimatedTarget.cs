using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetAnimatedTarget : MonoBehaviour
{
   
    PlayerController playerController;
    Animator animatedTargetAnimator;

    void Start()
    {
        playerController = FindObjectOfType<PlayerController>();
        if (playerController != null)
        {
            animatedTargetAnimator = playerController.GetComponent<Animator>();
            if (animatedTargetAnimator != null)
            {
                gameObject.GetComponent<CinemachineStateDrivenCamera>().m_AnimatedTarget = animatedTargetAnimator;
            }
            else
            {
                Debug.LogError("Animator component not found on the playerController's GameObject.");
            }
        }
        else
        {
            Debug.LogError("PlayerController not found in the scene.");
        }
    }

   
}
