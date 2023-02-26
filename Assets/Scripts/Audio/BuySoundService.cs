using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuySoundService : MonoBehaviour
{
    [SerializeField] private BuyPanel buyPanel;
    private AudioPoolService audioPoolService;
    
    [SerializeField] private AudioCastData buySound;

    private void Start()
    {
        audioPoolService = AudioPoolService.audioPoolServiceInstance;
        buyPanel.OnBuyEvent += CastBuySound;
    }

    private void CastBuySound()
    {
        audioPoolService.CastAudio(buySound);
    }
}
