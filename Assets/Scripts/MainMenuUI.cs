using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuUI : MonoBehaviour
{

    GameManager gameManager;
     void Start()
    {
       gameManager =  FindObjectOfType<GameManager>(); 
    }


    public void StartGame()
    {
        gameManager.LoadNextScene("Level 01");
    }

     void Update()
    {
        
    }
}
