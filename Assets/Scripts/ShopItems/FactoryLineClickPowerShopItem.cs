using UnityEngine;

public class FactoryLineClickPowerShopItem : ShopItem
{
    [SerializeField] private GlobalFactoryLine globalFactoryLine;

    [SerializeField] private float[] levelClickPower;


    public override void BuyItem()
    {
        globalFactoryLine.SetNewClickPower(levelClickPower[currentLevel]);
    }
}
