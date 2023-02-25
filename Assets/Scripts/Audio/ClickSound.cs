using UnityEngine;

public class ClickSound : MonoBehaviour
{
    private AudioPoolService audioPoolService;
    [SerializeField] private AudioCastData clickSoundData;

    private void Start()
    {
        audioPoolService = AudioPoolService.audioPoolServiceInstance;
    }

    public void CastClickSound()
    {
        audioPoolService.CastAudio(clickSoundData);
    }

}
