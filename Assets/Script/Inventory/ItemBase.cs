using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="ItemData",menuName ="Item")]
public class ItemBase : ScriptableObject
{
    public int ID;
    public string Name;
    public Sprite Image;
    public int price;
    public int MaxCapacity;
    [TextArea(1, 5)]//cho phep nhap van ban
    public string description;
}
