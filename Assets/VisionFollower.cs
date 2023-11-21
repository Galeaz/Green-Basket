using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisionFollower : MonoBehaviour
{
    [SerializeField] private Transform cameraTransform;
    [SerializeField] private float distance = 3.0f;

    private bool isCentered = false;

    private void OnBecomeInvinsible() {
        isCentered = false;
    }

    private void Update() 
    {
        if (!isCentered)
        {
        Vector3 targetPosition = FindTargetPosition();   
        MoveTowards(targetPosition); 
        if(ReachedPosition(targetPosition)) {
            isCentered = true;
        }
        }
    }

    private Vector3 FindTargetPosition() 
    {
        return cameraTransform.position + (cameraTransform.forward * distance);
    }

    private void MoveTowards(Vector3 targetPosition)
    {
        transform.position += (targetPosition  - transform.position) * 0.025f;
    }

    private bool ReachedPosition(Vector3 targetPosition)
    {
        return Vector3.Distance(targetPosition, transform.position) < 0.1f;
    }
}
