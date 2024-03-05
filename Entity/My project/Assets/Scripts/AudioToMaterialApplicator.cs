using Lasp;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class AudioToMaterialApplicator : MonoBehaviour
{
    [SerializeField] private AudioLevelEvent audioLevelEvent;
    [SerializeField] private float minSpeed; 
    [SerializeField] private float maxSpeed;
    //[SerializeField] private VisualEffect VFX; 
    [SerializeField] private Light PointLight;
    [SerializeField] private Material lavaShader; 
    [SerializeField] private float minIntensity = 0f; 
    [SerializeField] private float maxIntensity = 500f;
   // [SerializeField] private float smoothTime = 0.4f;
    //[SerializeField] private float materialSpeed = 0f;
       
    private void Start()
    {
        audioLevelEvent.audioLevelUpdated += OnAudioLevelUpdate;
    }
    private void OnDestroy()
    {
        audioLevelEvent.audioLevelUpdated -= OnAudioLevelUpdate;
    }
    private void OnAudioLevelUpdate(float normalizedAudioLevel)
    {
        lavaShader.SetFloat("_lowPassValue", Mathf.Lerp(minSpeed, maxSpeed, normalizedAudioLevel));
        //VFX.SetFloat("forceTest", normalizedAudioLevel * 100f);
        PointLight.intensity  = (Mathf.Lerp(minIntensity, maxIntensity, normalizedAudioLevel));
        //Mathf.SmoothDamp(PointLight.intensity, minIntensity, ref normalizedAudioLevel, smoothTime);
    }
    
}
