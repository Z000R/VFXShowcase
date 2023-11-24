using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunIntensity : MonoBehaviour
{
    public float minIntensity = 0.1f;
    public float maxIntensity = 2.0f;
    public float lerpSpeed = 5f;
    public float scrollSensitivity = 0.1f;

    private Light sunLight;

    void Start()
    {
        // Ensure there is a Light component attached to the GameObject
        sunLight = GetComponent<Light>();
        if (sunLight == null || sunLight.type != LightType.Directional)
        {
            Debug.LogError("No directional Light component found on the GameObject. Add a directional Light component to use this script.");
            enabled = false; // Disable the script if there is no directional Light component
        }
    }

    void Update()
    {
        // Get the scroll wheel input
        float scrollWheel = Input.GetAxis("Mouse ScrollWheel");

        // Adjust the sun intensity based on the scroll input
        AdjustSunIntensity(scrollWheel * scrollSensitivity);
    }

    void AdjustSunIntensity(float scrollDelta)
    {
        // Get the current intensity of the sun
        float currentIntensity = sunLight.intensity;

        // Calculate the target intensity based on the scroll input
        float targetIntensity = Mathf.Clamp(currentIntensity + scrollDelta, minIntensity, maxIntensity);

        // Lerp smoothly to the target intensity
        float lerpedIntensity = Mathf.Lerp(currentIntensity, targetIntensity, Time.deltaTime * lerpSpeed);

        // Set the lerped intensity to the sun
        sunLight.intensity = lerpedIntensity;
    }
}
