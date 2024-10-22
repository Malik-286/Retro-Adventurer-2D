using System.Collections;
using System.Collections.Generic;
using Unity.Cinemachine;
using UnityEngine;

public class ScreenShake : MonoBehaviour
{

    public CinemachineImpulseSource source;

     void Start()
    {
        source = GetComponent<CinemachineImpulseSource>();
    }

   public void ShakeScreen()
    {
        source.GenerateImpulse();
        Debug.Log("Shaking Screen...");
    }
}
