using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingletonScript<T> : MonoBehaviour where T : MonoBehaviour
{                                   // Á¦³×¸¯À¸·Î ½Ì±ÛÅæ ±¸Çö
    private static T instance;
    public static T Instance
    {
        get
        {
            if (instance == null)
            {
                GameObject obj = new GameObject(typeof(T).Name);
                instance = obj.AddComponent<T>();
            }
            return instance;
        }
    }
    protected virtual void Awake()
    {
        if(instance == null)
        {
            instance = this as T;
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
