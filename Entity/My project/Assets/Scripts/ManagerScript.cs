using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerScript : MonoBehaviour
#region Variables
{
    //variables for camera rotation
    [SerializeField]
    private float _mouseSensitivity = 3.0f;
    [SerializeField] GameObject Camera;

    private float _rotationY;
    private float _rotationX;

    [SerializeField]
    private Transform _target;

    [SerializeField]
    private float _distanceFromTarget = 3.0f;

    private Vector3 _currentRotation;
    private Vector3 _smoothVelocity = Vector3.zero;

    [SerializeField]
    private float _smoothTime = 0.2f;

    [SerializeField]
    private Vector2 _rotationXMinMax = new Vector2(-40, 40);

    // Variables for object scaling
    public Transform sphereScale;
    public float scaleSpeed = 5.0f;
    public float minScale = 0.1f;
    public float maxScale = 20.0f;
    public float scrollIntensity;
    public float scaleSmoothTime = 0.1f;
    private Vector3 currentScaleVelocity;

    // Variables for directional light control
    public Light directionalLight;
    public float intensitySpeed = 1.0f;
    public float maxIntensity = 5.0f;
    private float currentIntensityVelocity;
    public float intensitySmoothTime = 0.2f;

    // Variables for smooth damp
    [SerializeField]
    
    
    #endregion 
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * _mouseSensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * _mouseSensitivity;

        _rotationY += mouseX;
        _rotationX += mouseY;

        // Apply clamping for x rotation 
        _rotationX = Mathf.Clamp(_rotationX, _rotationXMinMax.x, _rotationXMinMax.y);

        Vector3 nextRotation = new Vector3(_rotationX, _rotationY);

        // Apply damping between rotation changes
        _currentRotation = Vector3.SmoothDamp(_currentRotation, nextRotation, ref _smoothVelocity, _smoothTime);
        Camera.transform.localEulerAngles = _currentRotation;

        // Substract forward vector of the GameObject to point its forward vector to the target
        Camera.transform.position = _target.position - Camera.transform.forward * _distanceFromTarget;

        // Scaling with mouse wheel
        float scrollWheel = Input.GetAxis("Mouse ScrollWheel") * scrollIntensity;
        ScaleObject(scrollWheel);

        // Controlling directional light intensity with right mouse button drag
        if (Input.GetMouseButton(1))
        {
            float _mouseY = Input.GetAxis("Mouse Y");
            AdjustLightIntensity(_mouseY);
        }
    }

    void ScaleObject(float scaleAmount)
    {
        // Calculate target scale
        Vector3 targetScale = sphereScale.localScale + Vector3.one * scaleAmount * scaleSpeed;
        targetScale = Vector3.ClampMagnitude(targetScale, maxScale);
        targetScale = Vector3.Max(targetScale, Vector3.one * minScale);

        // Smoothly damp the scale
        sphereScale.localScale = Vector3.SmoothDamp(sphereScale.localScale, targetScale, ref currentScaleVelocity, scaleSmoothTime);
    }

    void AdjustLightIntensity(float mouseY)
    {
        // Calculate target intensity
        float targetIntensity = directionalLight.intensity + mouseY * intensitySpeed;
        targetIntensity = Mathf.Clamp(targetIntensity, 0.0f, maxIntensity);

        // Smoothly damp the intensity
        directionalLight.intensity = Mathf.SmoothDamp(directionalLight.intensity, targetIntensity, ref currentIntensityVelocity, intensitySmoothTime);
    }
}
