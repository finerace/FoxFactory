using System;
using UnityEngine;

public class StorehouseShopItem : ShopItem
{
    [SerializeField] private Storehouse storehouse;

    [SerializeField] private int[] levelMaxResourceCount;
    [SerializeField] private int[] levelResourceQualityUp;

    private new void Awake()
    {
        BuyItem();
        
        base.Awake();
    }

    public override void BuyItem()
    {
        storehouse.SetNewMaxResourceCount(levelMaxResourceCount[currentLevel-1]);
        storehouse.SetResourceQualityUp(levelResourceQualityUp[currentLevel-1]);
    }
}
