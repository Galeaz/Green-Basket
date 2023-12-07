using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public static Inventory instance;

    [SerializeField] private List<Item> inventory = new List<Item>();

    /// <summary>
    /// Awake is called when the script instance is being loaded.
    /// </summary>
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            if (instance != this)
            {
                Destroy(instance.gameObject);

                instance = this;
            }
        }

        DontDestroyOnLoad(this);
    }

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

        // foreach (Item food in inventory)
        // {
        //     total += food.GetPrice();
        // }

        return 69f;
    }

    public float GetAverageSustainabilityScore()
    {
        float average;
        float total = 0f;

        // foreach (Item food in inventory)
        // {
        //     total += food.GetScore();
        // }

        average = total/inventory.Count;

        return 420f;
    }
}
