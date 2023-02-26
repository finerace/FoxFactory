using System;
using UnityEngine;

public class FactoryLineSoundService : MonoBehaviour
{

    [SerializeField] private AudioSource soundSource;

    [SerializeField] private GlobalFactoryLine globalFactoryLine;
    [SerializeField] private GlobalFactoryLineAutoMovement factoryLineAutoMovement;

    [Space] 
    
    [SerializeField] private float maxVolume = 0.6f;
    
    [Space]
    
    [SerializeField] private float clickEffectMultiplier = 1;
    [SerializeField] private float autoMovementEffectMultiplier;
    [SerializeField] private float changeVolumeSpeed = 5;

    private float targetVolume;
    
    private void Awake()
    {
        soundSource.loop = true;
        soundSource.Play();

        globalFactoryLine.OnFactoryLineClickMoveEvent += OnClickVolumeLouderChange;
    }
    
    private void Update()
    {
        SmoothSoundVolumeChange();
    }

    private void SmoothSoundVolumeChange()
    {
        var currentVolume = soundSource.volume;

        targetVolume = factoryLineAutoMovement.AutoMovementPower * autoMovementEffectMultiplier;
        
        var timeStep = Time.deltaTime * changeVolumeSpeed;
        currentVolume = Mathf.Lerp(currentVolume, targetVolume, timeStep);

        if (currentVolume > maxVolume)
            currentVolume = maxVolume;

        soundSource.volume = currentVolume;
    }

    private void OnClickVolumeLouderChange(float clickPower)
    {
        soundSource.volume += clickPower * clickEffectMultiplier;
    }
    
}
