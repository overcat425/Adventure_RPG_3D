using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    public List<GameObject>[] objectPool;
    public GameObject[] objects;
    private void Awake()
    {
        objectPool = new List<GameObject>[objects.Length];
        for (int i = 0; i < objects.Length; i++)
        {
            objectPool[i] = new List<GameObject>();
        }
    }
    public GameObject CreateObject(int i)
    {
        GameObject active = null;
        foreach (GameObject item in objectPool[i])
        {
            if (!item.activeSelf)
            {
                active = item;
                active.SetActive(true);
                break;
            }
        }
        if (!active)
        {
            active = Instantiate(objects[i], transform);
            objectPool[i].Add(active);
        }
        return active;
    }
}
