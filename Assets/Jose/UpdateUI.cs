using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateUI : MonoBehaviour
{
    public Text scoreText;
    public Text totalText;

    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = "Average Score: " + Inventory.instance.GetAverageSustainabilityScore();
        totalText.text = "Total Cost: " + Inventory.instance.GetTotalPrice().ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
