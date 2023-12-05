using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsRIg : MonoBehaviour
{
    [SerializeField] private Transform playerHead;
    [SerializeField] private CapsuleCollider bodyCollider;

    [SerializeField] private float bodyHeightMin = 0.5f;
    [SerializeField] private float bodyHeightMax = 2;

    // Update is called once per frame
    void FixedUpdate()
    {
        bodyCollider.height = Mathf.Clamp(playerHead.localPosition.y, bodyHeightMin, bodyHeightMax);
        bodyCollider.center = new Vector3(playerHead.localPosition.x, bodyCollider.height/2, playerHead.localPosition.z);
    }
}
