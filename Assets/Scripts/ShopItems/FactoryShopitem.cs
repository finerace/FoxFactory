using UnityEngine;

public class FactoryShopitem : ShopItem
{
    [Space]
    [SerializeField] private FoxFactory foxFactory;

    [Space] 
    
    [SerializeField] private int[] levelResourceQualityFactor;
    
    
    private new void Awake()
    {
        BuyItem();
        
        base.Awake();
    }

    public override void BuyItem()
    {
        if(currentLevel == 0)
            return;
        
        foxFactory.SetResourceQualityFactor(levelResourceQualityFactor[currentLevel-1]);
    }
}
