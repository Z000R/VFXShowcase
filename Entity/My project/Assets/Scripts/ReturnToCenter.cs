using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReturnToCenter : MonoBehaviour
{
    // Serialized field for the target position
    [SerializeField]
    public GameObject targetPosition;
    

    // Variables for smooth damp
    [SerializeField]
    private float smoothTime = 0.5f;
    private Vector3 velocity;

    void Update()
    {
        // Smoothly move towards the target position
        transform.position = Vector3.SmoothDamp(this.transform.position, targetPosition.transform.position, ref velocity, smoothTime);
    }
}
