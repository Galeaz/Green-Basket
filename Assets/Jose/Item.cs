using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField, TextArea(minLines: 2, maxLines: 6)] private string itemDesc;
    [SerializeField] private string itemName;
    [SerializeField] private int sustScore;
    [SerializeField] private float itemPrice;

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
