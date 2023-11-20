using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetPlayerPosition : MonoBehaviour
{
   private Vector3 startPosition;

    void Start()
    {
        // Store the initial position when the scene starts
        startPosition = transform.position;
    }

    public void ResetPosition()
    {
        // Reset the player's position to the stored starting position
        transform.position = startPosition;
    }
}
