using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuUI : MonoBehaviour
{

    GameManager gameManager;
    [SerializeField] string startingLevelToLoad;
     void Start()
    {
       gameManager =  FindObjectOfType<GameManager>(); 
    }


    public void StartGame()
    {
        if(gameManager != null)
        {
            gameManager.LoadNextScene(startingLevelToLoad);
        }
         
    }

     void Update()
    {
        
    }
}
