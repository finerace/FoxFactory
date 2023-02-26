using UnityEngine;

public class FoxBuyService : MonoBehaviour
{
    [SerializeField] private Transform fox;
    [SerializeField] private ShopItem shopItem;
    [SerializeField] private ParticleSystem smokeParticle;
    [SerializeField] private int targetLevel;

    private bool isFoxSpawned = false;
    
    private void Awake()
    {
        fox.gameObject.SetActive(false);

        shopItem.OnShopItemLevelUp += SpawnFox;
    }

    private void SpawnFox(int level)
    {
        if(isFoxSpawned)
            return;
        
        if (level >= targetLevel)
        {
            isFoxSpawned = true;
            
            fox.gameObject.SetActive(true);
            smokeParticle.Play();
        }
    }
    
}
