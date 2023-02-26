using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BuyPanel : MonoBehaviour
{
    [SerializeField] private PlayerMoneyService playerMoneyService;
    [SerializeField] private ShopItem currentShopItem;
    [SerializeField] private SimpleMenuService menuService;
    
    [Space]
    
    [SerializeField] private TMP_Text itemLevelLabel;
    [SerializeField] private TMP_Text itemNameLabel;
    [SerializeField] private TMP_Text itemDescLabel;
    [SerializeField] private TMP_Text itemPriceLabel;

    [Space] 
    
    [SerializeField] private Image itemImage;
    
    private event Action onBuyEvent;
    
    public event Action OnBuyEvent
    {
        add => onBuyEvent += value ?? throw new NullReferenceException();
        remove => onBuyEvent += value ?? throw new NullReferenceException();
    }
    
    public void SetNewBuyPanelValues(ShopItem shopItem)
    {
        if(shopItem.CurrentLevel > shopItem.MaxLevels)
            return;
        
        itemLevelLabel.text = $"Уровень {shopItem.CurrentLevel}/{shopItem.MaxLevels}";
        itemNameLabel.text = shopItem.ItemName;
        itemDescLabel.text = shopItem.ItemDescription;

        if (shopItem.CurrentLevel < shopItem.MaxLevels)
            itemPriceLabel.text = $"{shopItem.LevelCosts[shopItem.CurrentLevel-1]} Монет";
        else
            itemPriceLabel.text = $"Всё куплено";

        //itemImage.sprite = shopItem.LevelMaterials[shopItem.CurrentLevel];

        currentShopItem = shopItem;
    }

    public void BuyItem()
    {
        if(currentShopItem.CurrentLevel >= currentShopItem.MaxLevels)
            return;
        
        if(currentShopItem.CurrentLevel >= currentShopItem.LevelCosts.Length)
            return;
        
        if (playerMoneyService.MoneyCount >= currentShopItem.LevelCosts[currentShopItem.CurrentLevel-1])
        {
            playerMoneyService.MoneyCount -= currentShopItem.LevelCosts[currentShopItem.CurrentLevel-1];

            currentShopItem.UpgradeItemLevel();
            currentShopItem.BuyItem();

            SetNewBuyPanelValues(currentShopItem);
            
            onBuyEvent?.Invoke();
            
            menuService.OpenMenu(0);
        }
    }
    
}
