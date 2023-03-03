using System;
using UnityEngine;
using UnityEngine.EventSystems;

public abstract class ShopItem : MonoBehaviour,IPointerClickHandler
{
    [SerializeField] protected string itemName;
    [SerializeField] protected string itemDescription;
    
    [Range(2,16)] [SerializeField] protected int maxLevels;
    [Range(1,16)] [SerializeField] protected int currentLevel;

    [Space] 
    
    [SerializeField] protected int[] levelCosts = new int[1];
    public int[] LevelCosts => levelCosts;
    
    [SerializeField] protected Sprite[] levelImages = new Sprite[1];
    public Sprite[] LevelImages => levelImages;
    
    private event Action<int> onShopItemLevelUp;
    public event Action<int> OnShopItemLevelUp
    {
        add => onShopItemLevelUp += value ?? throw new NullReferenceException();

        remove => onShopItemLevelUp -= value ?? throw new NullReferenceException();
    }
    
    private event Action onShopItemClick;
    public event Action OnShopItemClick
    {
        add => onShopItemClick += value ?? throw new NullReferenceException();

        remove => onShopItemClick -= value ?? throw new NullReferenceException();
    }

    [SerializeField] protected bool ignoreItemMesh;
    [SerializeField] protected MeshRenderer itemMesh;
    [SerializeField] protected Material[] levelItemMat;
    public Material[] LevelItemMat => levelItemMat;

    [Space] 
    
    [SerializeField] private ParticleSystem smokeParticle;
    
    [Space]
    
    private PlayerMoneyService playerMoneyService;
    [SerializeField] private Transform notificationSprite;
    
    private SimpleMenuService simpleMenuService;
    private BuyPanel buyPanel;

    [SerializeField] private bool isItemCanBuy = false;
    public bool IsItemCanBuy => isItemCanBuy;
    
    public string ItemName => itemName;
    public string ItemDescription => itemDescription;
    public int MaxLevels => maxLevels;
    public int CurrentLevel => currentLevel;

    public void Awake()
    {
        simpleMenuService = FindObjectOfType<SimpleMenuService>();
        buyPanel = FindObjectOfType<BuyPanel>();

        playerMoneyService = FindObjectOfType<PlayerMoneyService>();
        
        playerMoneyService.OnMoneyCountChange += CheckForUpgrade;
    }

    public void UpgradeItemLevel()
    {
        if(currentLevel >= maxLevels)
            return;
        
        currentLevel += 1;
        
        onShopItemLevelUp?.Invoke(currentLevel);
        
        if(!ignoreItemMesh)
            itemMesh.material = levelItemMat[currentLevel-1];
        
        if(smokeParticle != null)
            smokeParticle.Play();
        
    }

    private void OpenBuyPanel()
    {
        buyPanel.SetNewBuyPanelValues(this);
        simpleMenuService.OpenMenu(1);
    }
    
    public abstract void BuyItem();

    private void CheckForUpgrade(int currency)
    {
        if(currentLevel >= maxLevels)
        {
            notificationSprite.gameObject.SetActive(false);
            isItemCanBuy = false;
            
            return;
        }

        var currentUpdatePrice = levelCosts[currentLevel-1];

        isItemCanBuy = currency >= currentUpdatePrice;
        notificationSprite.gameObject.SetActive(isItemCanBuy);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        OpenBuyPanel();
        onShopItemClick?.Invoke();
    }
}
