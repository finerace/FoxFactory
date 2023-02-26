using UnityEngine;

public class FabricLineAutoMovementShopItem : ShopItem
{
    [SerializeField] private GlobalFactoryLineAutoMovement fabricLineAutoMovement;

    [SerializeField] private float[] levelsAutoMovementPower;
    
    private new void Awake()
    {
        BuyItem();      
        
        base.Awake();
    }

    public override void BuyItem()
    {
        if(currentLevel == 0)
            return;
        
        fabricLineAutoMovement.SetAutoMovementPower(levelsAutoMovementPower[currentLevel-1]);
    }
}
