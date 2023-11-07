using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestAdd : MonoBehaviour
{
    public Inventory inventory;
    public Item newItem;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // if (Input.GetKeyDown(KeyCode.Space))
        // {
        //     inventory.AddItem(newItem);
        // }

        // if (Input.GetKeyDown(KeyCode.R))
        // {
        //     inventory.RemoveItem(newItem);
        // }
    }

    /// <summary>
    /// OnTriggerEnter is called when the Collider other enters the trigger.
    /// </summary>
    /// <param name="other">The other Collider involved in this collision.</param>
    private void OnTriggerEnter(Collider other)
    {
        inventory.AddItem(other.GetComponent<Item>());
    }

    /// <summary>
    /// OnTriggerExit is called when the Collider other has stopped touching the trigger.
    /// </summary>
    /// <param name="other">The other Collider involved in this collision.</param>
    private void OnTriggerExit(Collider other)
    {
        inventory.RemoveItem(other.GetComponent<Item>());
    }
}
