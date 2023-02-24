using UnityEngine;

public class FabricLineAutoMovementShopItem : ShopItem
{
    [SerializeField] private GlobalFactoryLineAutoMovement fabricLineAutoMovement;

    [SerializeField] private float[] levelsAutoMovementPower;
    
    public override void BuyItem()
    {
        fabricLineAutoMovement.SetAutoMovementPower(levelsAutoMovementPower[currentLevel]);
    }
}
