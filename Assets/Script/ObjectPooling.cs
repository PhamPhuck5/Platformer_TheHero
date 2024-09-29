using System;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooling : Singleton<ObjectPooling>
{
    [Serializable]public class pool
    {
        public string Name;
        public GameObject prefab;
        public int quantiti=-1;
    }
    [SerializeField] List<pool> pools = new List<pool>();
     public Dictionary<string, Queue<GameObject>> PoolDictionary;

    protected override void Awake()
    {
        base.Awake();
        CreatePoolDictionaly();
    }
    private void CreatePoolDictionaly()
    {
        PoolDictionary = new Dictionary<string, Queue<GameObject>>();
        foreach (pool Item in pools)
        {
            Queue<GameObject> Temp = new Queue<GameObject>();
            if (Item.quantiti != -1)
            {
                for (int i = 0; i < Item.quantiti; i++)
                {
                    GameObject NewObj = Instantiate(Item.prefab);
                    NewObj.SetActive(false);
                    Temp.Enqueue(NewObj);
                }
            }
            PoolDictionary.Add(Item.Name, Temp);
        }
        pools.Clear();
    }
    public void AddToDictionaly(String _Name,GameObject _GameObject)
    {
        if (PoolDictionary[_Name]== null)
        {
            Queue<GameObject> Temp = new Queue<GameObject>();
            PoolDictionary.Add(_Name, Temp);
        }
        PoolDictionary[_Name].Enqueue(_GameObject);
    }
    public void die(GameObject DieEnemy,string name)
    {
        PoolDictionary[name].Enqueue(DieEnemy);
        DieEnemy.SetActive(false);
    }


}
