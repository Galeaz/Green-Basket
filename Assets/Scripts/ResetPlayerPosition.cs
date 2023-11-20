using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetPlayerPosition : MonoBehaviour
{
    public Vector3 playerPosition;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = playerPosition;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
