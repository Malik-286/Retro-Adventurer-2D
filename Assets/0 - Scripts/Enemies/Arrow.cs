using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{


    [SerializeField] float arrowMoveSpeed = -10f;
    [SerializeField] float destroyTime = 1.5f;

    [SerializeField] bool isthisRightArrow;
    [SerializeField] bool isthisLeftArrow;


    void Start()
    {
        Destroy(gameObject,destroyTime);
    }

    void Update()
    {
        if (isthisLeftArrow)
        {
            transform.Translate(arrowMoveSpeed * Time.deltaTime, 0, 0);
        }else if (isthisRightArrow)
        {
            transform.Translate(-arrowMoveSpeed * Time.deltaTime, 0, 0);
        }
        
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject, 0.1f);
        }
    }


}
