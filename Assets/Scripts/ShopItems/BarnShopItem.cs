using UnityEngine;

public class BarnShopItem : ShopItem
{
    [SerializeField] private FoxBarn foxBarn;

    [SerializeField] private float[] foxBarnLevelSpawnFactor;
    
    public override void BuyItem()
    {
        foxBarn.SetResourceSpawnRate(foxBarnLevelSpawnFactor[currentLevel]);
    }
}
