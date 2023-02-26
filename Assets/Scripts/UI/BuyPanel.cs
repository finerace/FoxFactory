using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BuyPanel : MonoBehaviour
{
    [SerializeField] private PlayerMoneyService playerMoneyService;
    [SerializeField] private ShopItem currentShopItem;
    
    [Space]
    
    [SerializeField] private TMP_Text itemLevelLabel;
    [SerializeField] private TMP_Text itemNameLabel;
    [SerializeField] private TMP_Text itemDescLabel;
    [SerializeField] private TMP_Text itemPriceLabel;

    [Space] 
    
    [SerializeField] private Image itemImage;

    public void SetNewBuyPanelValues(ShopItem shopItem)
    {
        itemLevelLabel.text = $"Уровень {shopItem.CurrentLevel}/{shopItem.MaxLevels}";
        itemNameLabel.text = shopItem.ItemName;
        itemDescLabel.text = shopItem.ItemDescription;

        if (shopItem.CurrentLevel != shopItem.MaxLevels)
            itemPriceLabel.text = $"{shopItem.LevelCosts[shopItem.CurrentLevel]} Монет";
        else
            itemPriceLabel.text = $"Куплено";

        //itemImage.sprite = shopItem.LevelMaterials[shopItem.CurrentLevel];

        currentShopItem = shopItem;
    }

    public void BuyItem()
    {
        if(currentShopItem.CurrentLevel >= currentShopItem.LevelCosts.Length)
            return;
        
        if (playerMoneyService.MoneyCount >= currentShopItem.LevelCosts[currentShopItem.CurrentLevel])
        {
            playerMoneyService.MoneyCount -= currentShopItem.LevelCosts[currentShopItem.CurrentLevel];
            
            currentShopItem.BuyItem();
            currentShopItem.UpgradeItemLevel();
            
            SetNewBuyPanelValues(currentShopItem);
        }
    }
    
}
