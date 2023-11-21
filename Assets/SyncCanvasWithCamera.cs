using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SyncCanvasWithCamera : MonoBehaviour
{
    private Transform mainCameraTransform;

    private void Start()
    {
        // Find the main camera in the scene
        Camera mainCamera = Camera.main;

        if (mainCamera != null)
        {
            // Get the main camera's transform
            mainCameraTransform = mainCamera.transform;
        }
        else
        {
            Debug.LogError("Main camera not found in the scene. Make sure there is a camera tagged as 'MainCamera'.");
        }
    }

    private void Update()
    {
        if (mainCameraTransform != null)
        {
            // Synchronize the canvas's transform and rotation with the main camera
            transform.position = mainCameraTransform.position;
            transform.rotation = mainCameraTransform.rotation;
        }
    }
}
