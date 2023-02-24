using UnityEngine;

public class FactoryShopitem : ShopItem
{
    [Space]
    [SerializeField] private FoxFactory foxFactory;

    [Space] 
    
    [SerializeField] private float[] levelResourceQualityFactor;
    
    public override void BuyItem()
    {
        foxFactory.SetResourceQualityFactor(levelResourceQualityFactor[currentLevel]);
    }
}
