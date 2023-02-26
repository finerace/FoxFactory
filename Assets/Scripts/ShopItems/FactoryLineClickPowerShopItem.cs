using UnityEngine;

public class FactoryLineClickPowerShopItem : ShopItem
{
    [SerializeField] private GlobalFactoryLine globalFactoryLine;

    [SerializeField] private float[] levelClickPower;

    private new void Awake()
    {
        BuyItem();
        
        base.Awake();
    }

    public override void BuyItem()
    {
        globalFactoryLine.SetNewClickPower(levelClickPower[currentLevel]);
    }
}
