using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class follower : MonoBehaviour
{
    public Transform target; // The target object to follow
    public float followDelay = 1.0f; // Delay in seconds before the object starts following
    public float followSpeed = 5.0f; // Speed at which the object follows

    private Vector3 targetPosition; // Position of the target object with delay

    void Update()
    {

        if (target != null)
        {
            // Update the targetPosition with the target's current position but with a delay
            targetPosition = Vector3.Lerp(transform.position, target.position, Time.deltaTime / followDelay);

            // Move the object towards the targetPosition with the specified speed
            transform.position = Vector3.Lerp(transform.position, targetPosition, followSpeed * Time.deltaTime);
        }
        
    }
}
