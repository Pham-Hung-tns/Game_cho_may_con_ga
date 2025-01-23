using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    public Dictionary<string, Queue<GameObject>> pool = new Dictionary<string, Queue<GameObject>>();

    public static ObjectPool Instance;
    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        DontDestroyOnLoad(gameObject);
    }

    public GameObject Initialization(GameObject obj)
    {
        if (pool.TryGetValue(obj.name, out Queue<GameObject> queue))
        {
            if (queue.Count == 0)
            {
                return CreateNewGO(obj);
            }
            else
            {
                GameObject newGO = queue.Dequeue();
                return newGO;
            }
        }
        else
            return CreateNewGO(obj);
    }

    private GameObject CreateNewGO(GameObject obj)
    {
        GameObject newGO = Instantiate(obj);
        newGO.name = obj.name;
        newGO.gameObject.SetActive(false);
        return newGO;
    }

    public void ReturnGO(GameObject obj)
    {
        if (pool.TryGetValue(obj.name, out Queue<GameObject> queue))
        {
            queue.Enqueue(obj);
        }
        else
        {
            Queue<GameObject> newQueue = new Queue<GameObject>();
            newQueue.Enqueue(obj);
            pool.Add(obj.name, newQueue);
        }
        obj.gameObject.SetActive(false);
    }
}
