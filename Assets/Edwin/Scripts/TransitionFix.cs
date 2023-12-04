using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransitionFix : MonoBehaviour
{
    // Define offsets for X, Y, and Z axes in the local space of the camera
    public float offsetX = -100f;
    public float offsetY = -50f;
    public float offsetZ = 0.015f;//

    void Update()
    {
        // Get the camera's forward, up, and right directions
        Vector3 cameraForward = Camera.main.transform.forward;
        Vector3 cameraUp = Camera.main.transform.up;
        Vector3 cameraRight = Camera.main.transform.right;

        // Create an offset vector by combining forward, up, and right directions with X, Y, and Z offsets
        Vector3 offset = offsetX * cameraRight + offsetY * cameraUp + offsetZ * cameraForward;

        // Match the position and rotation of the object to the main camera with the calculated offset
        gameObject.transform.position = Camera.main.transform.position + offset;
        gameObject.transform.rotation = Camera.main.transform.rotation;
    }

}
