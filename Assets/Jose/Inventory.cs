using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField] private List<Item> inventory = new List<Item>();

    public void AddItem(Item newItem)
    {
        inventory.Add(newItem);
    }

    public void RemoveItem(Item oldItem)
    {
        inventory.Remove(oldItem);
    }
}
