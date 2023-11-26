using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Lasp;
using System;

public class AudioLevelEvent : MonoBehaviour
{
    [SerializeField] private AudioLevelTracker audioTracker;
    public event Action<float> audioLevelUpdated; 

    private void Update()
    {
        audioLevelUpdated?.Invoke(audioTracker.normalizedLevel);

    }
}
