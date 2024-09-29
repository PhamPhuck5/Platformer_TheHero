using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalVariable : MonoBehaviour
{
    static public int LayerTerrantToInt { get; private set;}
    static public int EnemyLayer { get; private set; }
    static public bool IsLoad = false;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        LayerTerrantToInt = (1 << LayerMask.NameToLayer("Terrant"));
        EnemyLayer = ~(1 << LayerMask.NameToLayer("Enemy"));
    }
}
