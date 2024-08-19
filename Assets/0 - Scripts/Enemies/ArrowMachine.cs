using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class ArrowMachine : MonoBehaviour
{

    [SerializeField] GameObject arrowPrefeb;
    [SerializeField] Transform arrowShootPosition;
    [SerializeField] AudioClip arrowShootSoundEfect;
    [SerializeField] AudioClip machineDestroySoundeffect;


    public bool isDestroyed = false;
    Animator animator;

    void Start()
    {

        animator = GetComponent<Animator>();
         InvokeRepeating(nameof(ThrowArrow), 2, 4); ;
    }

    public void ThrowArrow()
    {
        if (isDestroyed == true)
        {
            return;
        }

        GameObject arrowClone = Instantiate(arrowPrefeb, arrowShootPosition.position, quaternion.identity);
        if (AudioManager.GetInstance() != null)
        {
            AudioManager.GetInstance().PlaySingleShotAudio(arrowShootSoundEfect, 1.5f);
        }


    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            isDestroyed = true;
            if (isDestroyed == true)
            {
                if(AudioManager.GetInstance() != null)
                {
                    AudioManager.GetInstance().PlaySingleShotAudio(machineDestroySoundeffect, 1.0f);
                }
                animator.SetBool("isDestroyed", true);
                Destroy(gameObject, 3f);
            }

        }
    }

}
