using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrencyPanelAnimation : MonoBehaviour
{

    Animator animator;
     void Start()
    {
        animator = GetComponent<Animator>();    
    }

    public void PlayCoinIconAnimation()
    {
        animator.SetTrigger("Plus");
    }
}
