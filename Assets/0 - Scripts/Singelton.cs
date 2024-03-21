using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public  class Singelton<T>: MonoBehaviour where T : Singelton<T>
{
      static T instance;

    public static T GetInstance()
    {
        return instance;
    }
    void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = (T)this;
            DontDestroyOnLoad(gameObject);
        }
    }

     
}
