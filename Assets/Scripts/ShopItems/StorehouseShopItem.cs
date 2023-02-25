using UnityEngine;

public class StorehouseShopItem : ShopItem
{
    [SerializeField] private Storehouse storehouse;

    [SerializeField] private int[] levelMaxResourceCount;
    
    public override void BuyItem()
    {
        storehouse.SetNewMaxResourceCount(levelMaxResourceCount[currentLevel]);
    }
}
