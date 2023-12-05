using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CartFollower : MonoBehaviour
{
    [SerializeField] private Transform cameraTransform;
    [SerializeField] private float distance = 3.0f;
    [SerializeField] private Vector3 customPositionOffset = new Vector3(0f, 0f, 0f);
    [SerializeField] private Vector3 customRotationOffset = new Vector3(0f, 0f, 0f);

    private void Update()
    {
        // Get the camera's forward vector projected onto the horizontal plane
        Vector3 cameraForwardHorizontal = Vector3.ProjectOnPlane(cameraTransform.forward, Vector3.up).normalized;

        // Calculate the desired position based on the horizontal direction and custom offset
        Vector3 desiredPosition = cameraTransform.position + (cameraForwardHorizontal * distance) + customPositionOffset;

        // Set the position and rotation of the shopping cart
        transform.position = desiredPosition;
        transform.rotation = Quaternion.LookRotation(cameraForwardHorizontal, Vector3.up) * Quaternion.Euler(customRotationOffset);
    }
}
