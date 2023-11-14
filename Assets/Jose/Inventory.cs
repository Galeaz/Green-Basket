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

    public float GetTotalPrice()
    {
        float total = 0f;

        foreach (Item food in inventory)
        {
            total += food.GetPrice();
        }

        return total;
    }

    public float GetAverageSustainabilityScore()
    {
        float average = 0f;
        float total = 0f;

        foreach (Item food in inventory)
        {
            total += food.GetScore();
        }

        average = total/inventory.Count;

        return average;
    }
}
