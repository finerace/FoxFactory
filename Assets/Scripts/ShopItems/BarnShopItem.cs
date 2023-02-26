using UnityEngine;

public class BarnShopItem : ShopItem
{
    [SerializeField] private FoxBarn foxBarn;

    [SerializeField] private float[] foxBarnLevelSpawnFactor;
    [SerializeField] private int[] levelStartResourceQuality;
    
    private new void Awake()
    {
        BuyItem();
        
        base.Awake();
    }
    
    public override void BuyItem()
    {
        if(currentLevel == 0)
            return;
        
        foxBarn.SetResourceSpawnRate(foxBarnLevelSpawnFactor[currentLevel-1]);
        foxBarn.SetResourceStartQuality(levelStartResourceQuality[currentLevel-1]);
    }
}
