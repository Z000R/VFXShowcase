using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationLight : MonoBehaviour

{
    public float circleRadius = 5f; // Radius of the rotation circle
    public float rotationSpeed = 2f; // Speed of rotation in degrees per second
    public float yOffset = 0f; // Y position offset

    public Transform target; // Object to rotate around

    private float currentAngle = 0f; // Current angle around the target object

    private void Update()
    {
        // Calculate the desired position on the circle
        float x = Mathf.Sin(currentAngle * Mathf.Deg2Rad) * circleRadius;
        float z = Mathf.Cos(currentAngle * Mathf.Deg2Rad) * circleRadius;

        // Set the light's position relative to the target object
        Vector3 desiredPosition = target.position + new Vector3(x, yOffset, z);
        transform.position = desiredPosition;

        // Increment the angle based on the rotation speed
        currentAngle += rotationSpeed * Time.deltaTime;

        // Ensure the angle stays within 0-360 degrees
        if (currentAngle >= 360f)
        {
            currentAngle -= 360f;
        }
    }
}