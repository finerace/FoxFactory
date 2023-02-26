using UnityEngine;

public class FactoryShopitem : ShopItem
{
    [Space]
    [SerializeField] private FoxFactory foxFactory;

    [Space] 
    
    [SerializeField] private int[] levelResourceQualityFactor;
    
    public override void BuyItem()
    {
        foxFactory.SetResourceQualityFactor(levelResourceQualityFactor[currentLevel]);
    }
}
