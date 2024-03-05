using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    // Exposed variables
    [SerializeField] private AudioLevelEvent audioLevelEvent;
    public float shakeStrength = 0.1f; // Adjust this value to control the shake strength
    public float shakeDuration = 0.5f;
    public float shakeSpeed = 25f;

    private Vector3 originalPosition;

    void Start()
    {
        originalPosition = transform.position;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) // Trigger the shake for testing purposes (you can replace this condition)
        {
            StartShake();
        }
    }

    public void StartShake()
    {
        if (!IsInvoking("StopShake"))
        {
            InvokeRepeating("ApplyShake", 0, 0.01f);
            Invoke("StopShake", shakeDuration);
        }
    }

    private void ApplyShake()
    {
        float shakeAmountX = Random.Range(-1f, 1f) * shakeStrength;
        float shakeAmountY = Random.Range(-1f, 1f) * shakeStrength;

        Vector3 newPosition = originalPosition + new Vector3(shakeAmountX, shakeAmountY, 0);
        transform.position = Vector3.Lerp(transform.position, newPosition, Time.deltaTime * shakeSpeed);
    }

    private void StopShake()
    {
        CancelInvoke("ApplyShake");
        transform.position = originalPosition;
    }
}