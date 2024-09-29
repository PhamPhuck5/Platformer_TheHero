using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
    private static T _instance=null;
    public static T Instance
    {
        get
        {
            if (_instance == null)
            {
                Debug.LogWarning("----Singleton n't exist---");
                _instance = FindFirstObjectByType<T>();

 /*               if (_instance == null)
                {
                    GameObject singletonObject = new GameObject();
                    _instance = singletonObject.AddComponent<T>();
                    singletonObject.name = typeof(T).ToString() + " (Singleton)";
                }*/
            }

            return _instance;
        }
    }

    protected virtual void Awake()
    {
        if (_instance != null&& _instance.gameObject.GetInstanceID() != this.gameObject.GetInstanceID())
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this.GetComponent<T>();
        }
    }
}

