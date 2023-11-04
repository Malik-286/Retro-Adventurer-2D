using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillsCounter : MonoBehaviour
{
     


   [SerializeField] int killsCount;
    void Start()
    {
        killsCount = 0;
         
    }

    public int GetCurrentSceneKills()
    {
        return killsCount;
    }

    public void IncreaseKillsCount()
    {
        killsCount++;
    }

    public void ResetKillsCount()
    {
        killsCount = 0;
    }

    
    
}
