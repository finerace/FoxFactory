using System;
using UnityEngine;

public class CourierResourceSellSound : MonoBehaviour
{
    [SerializeField] private ResourceCourier resourceCourier;
    private AudioPoolService audioPoolService;
    
    [Space] 
    
    [SerializeField] private AudioCastData sound1;
    [SerializeField] private AudioCastData sound2;


    private void Start()
    {
        audioPoolService = AudioPoolService.audioPoolServiceInstance;

        resourceCourier.OnSellResourceEvent += CastSounds;
    }

    private void CastSounds(int sell)
    {
        audioPoolService.CastAudio(sound1);
        audioPoolService.CastAudio(sound2);
    }
    
}
