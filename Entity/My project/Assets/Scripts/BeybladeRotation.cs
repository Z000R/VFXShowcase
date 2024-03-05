using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeybladeRotation : MonoBehaviour
{
    public float initialRotationSpeed = 1000f; // Adjust the initial rotation speed
    public float slowdownRate = 10f; // Adjust the rate at which the rotation slows down

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        // Set initial rotation speed
        rb.angularVelocity = Random.onUnitSphere * initialRotationSpeed;
    }

    void FixedUpdate()
    {
        // Gradually slow down the rotation
        rb.angularVelocity = Vector3.Lerp(rb.angularVelocity, Vector3.zero, Time.fixedDeltaTime * slowdownRate);
    }
}