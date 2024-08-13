using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class ArrowMachine : MonoBehaviour
{

    [SerializeField] GameObject arrowPrefeb;

    void Start()
    {
        InvokeRepeating(nameof(ThrowArrow), 2, 4); ;
    }

    public void ThrowArrow()
    {
        GameObject arrowClone = Instantiate(arrowPrefeb, transform.position, quaternion.identity);
       

    }

      void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            Destroy(gameObject);
        }
    }

}
