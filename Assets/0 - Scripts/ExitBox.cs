using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitBox : MonoBehaviour
{


     [SerializeField] AudioClip levelCompletionSound;
 
     [SerializeField] List<GameObject> enemiesToDestroy;
     [SerializeField] GameObject levelCompletionPanel;
     [SerializeField] int nextLevelToUnlock;
  


  
    void Start()
    {   
         levelCompletionPanel.SetActive(false);
    }


    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if(GameManager.GetInstance() != null)
            {
                int index = GameManager.GetInstance().GetCurrentSceneIndex();
                PlayerPrefs.SetInt("Level" + index, 1);
                PlayerPrefs.Save();
            }
             
            

            DestroyRemaningEnemies();
            if (AudioManager.GetInstance() != null)
            {
                AudioManager.GetInstance().PlaySingleShotAudio(levelCompletionSound, 0.7f);
            }
            levelCompletionPanel.SetActive(true);
            collision.gameObject.SetActive(false);
            Destroy(gameObject, 0.5f);
          
        }

    }

    void DestroyRemaningEnemies()
    {
         for (int i = 0; i < enemiesToDestroy.Count; i++)
        {
            Destroy(enemiesToDestroy[i]);
        }

    }


    

}
