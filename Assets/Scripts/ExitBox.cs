using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitBox : MonoBehaviour
{


     [SerializeField] AudioClip levelCompletionSound;




    AudioManager audioManager;
     void Start()
    {
        audioManager = FindObjectOfType<AudioManager>();
    }


    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Level 01 Completed.");
            if (audioManager != null)
            {
                audioManager.PlaySingleShotAudio(levelCompletionSound, 0.7f);
                Destroy(gameObject);
            }
        }

    }

}
