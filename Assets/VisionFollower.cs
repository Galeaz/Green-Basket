using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisionFollower : MonoBehaviour
{
    [SerializeField] private Transform cameraTransform;
    [SerializeField] private float distance = 3.0f;

    private void Update() 
    {
       Vector3 desiredPosition = cameraTransform.position + (cameraTransform.forward * distance);
       transform.position = desiredPosition;
       transform.rotation = cameraTransform.rotation;
    }
}
