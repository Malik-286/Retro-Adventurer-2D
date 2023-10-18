using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitBox : MonoBehaviour
{


     [SerializeField] AudioClip levelCompletionSound;
     [SerializeField] string nextLevelToLoad;

     [SerializeField] List<GameObject> enemiesToDestroy;
 



    AudioManager audioManager;
    GameManager gameManager;
     void Start()
    {
        audioManager = FindObjectOfType<AudioManager>();
        gameManager = FindObjectOfType<GameManager>();
    }


    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
             if (audioManager != null)
            {
                DestroyRemaningEnemies();
                audioManager.PlaySingleShotAudio(levelCompletionSound, 0.7f);
                gameManager.LoadNextScene(nextLevelToLoad);
                Destroy(gameObject, 0.5f);
            }
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
