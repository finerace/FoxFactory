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
        fabricLineAutoMovement.SetAutoMovementPower(levelsAutoMovementPower[currentLevel]);
    }
}
