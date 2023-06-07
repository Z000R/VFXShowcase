using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CinemachineLerp : MonoBehaviour
{
    [SerializeField] private Cinemachine.CinemachineVirtualCamera cinemachine;
    [SerializeField] private float sensitivity = 10f;
    [SerializeField] private float smoothTime = 0.1f;

    private float targetFocalLength;
    private float currentVelocity;

    private void Start()
    {
        targetFocalLength = cinemachine.m_Lens.FieldOfView;
    }

    private void Update()
    {
        float scrollInput = Input.mouseScrollDelta.y;

        // Modify the target focal length based on the mouse scroll input
        targetFocalLength -= scrollInput * sensitivity;

        // Clamp the target focal length to a desired range (e.g., 1 to 100)
        targetFocalLength = Mathf.Clamp(targetFocalLength, 1f, 100f);

        // Smoothly lerp the current focal length towards the target focal length
        float newFocalLength = Mathf.SmoothDamp(cinemachine.m_Lens.FieldOfView, targetFocalLength, ref currentVelocity, smoothTime);

        // Update the virtual camera's focal length
        cinemachine.m_Lens.FieldOfView = newFocalLength;
    }
}
