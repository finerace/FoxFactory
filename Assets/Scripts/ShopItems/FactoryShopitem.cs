using UnityEngine;

public class FactoryShopitem : ShopItem
{
    [Space]
    [SerializeField] private FoxFactory foxFactory;
    
    
    public override void BuyItem()
    {
        foxFactory.UpgradeFactoryLevel();
    }
}
