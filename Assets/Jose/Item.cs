using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Item", menuName = "Grocery Item")]
public class Item : ScriptableObject
{
    [SerializeField, TextArea(minLines: 2, maxLines: 6)] private string itemDesc;
    [SerializeField] private string itemName;
    [SerializeField] private int sustScore;
    [SerializeField] private float itemPrice;
    [SerializeField] private Sprite itemSprite;

    public string GetDescription()
    {
        return itemDesc;
    }

    public string GetName()
    {
        return itemName;
    }

    public int GetScore()
    {
        return sustScore;
    }

    public float GetPrice()
    {
        return itemPrice;
    }
}
