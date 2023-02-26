using UnityEngine;

public class FactorySoundService : MonoBehaviour
{
    [SerializeField] private FoxFactory foxFactory;
    private AudioPoolService audioPoolService;
    
    [SerializeField] private AudioCastData factorySound;

    private void Start()
    {
        audioPoolService = AudioPoolService.audioPoolServiceInstance;
        foxFactory.ResourceInputEvent += CastFactorySound;
    }

    private void CastFactorySound()
    {
        audioPoolService.CastAudio(factorySound);
    }
}
