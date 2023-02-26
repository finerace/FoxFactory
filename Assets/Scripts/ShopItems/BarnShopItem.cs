using UnityEngine;

public class BarnShopItem : ShopItem
{
    [SerializeField] private FoxBarn foxBarn;

    [SerializeField] private float[] foxBarnLevelSpawnFactor;
    [SerializeField] private int[] levelStartResourceQuality;
    
    public override void BuyItem()
    {
        foxBarn.SetResourceSpawnRate(foxBarnLevelSpawnFactor[currentLevel]);
        foxBarn.SetResourceStartQuality(levelStartResourceQuality[currentLevel]);
    }
}
