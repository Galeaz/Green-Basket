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
        if (Input.GetKeyDown(KeyCode.Space))
        {
            inventory.AddItem(newItem);
        }
    }
}
