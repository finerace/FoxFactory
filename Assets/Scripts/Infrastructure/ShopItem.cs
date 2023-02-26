using UnityEngine;
using UnityEngine.EventSystems;

public abstract class ShopItem : MonoBehaviour,IPointerDownHandler,IPointerEnterHandler,IPointerExitHandler
{
    [SerializeField] protected string itemName;
    [SerializeField] protected string itemDescription;
    
    [Range(0,16)] [SerializeField] protected int maxLevels;
    [Range(0,16)] [SerializeField] protected int currentLevel;

    [Space] 
    
    [SerializeField] protected int[] levelCosts = new int[1];
    public int[] LevelCosts => levelCosts;
    
    [SerializeField] protected Sprite[] levelImages = new Sprite[1];
    public Sprite[] LevelImages => levelImages;

    [Space] 
    
    [SerializeField] protected bool ignoreItemMesh;
    [SerializeField] protected MeshRenderer itemMesh;
    [SerializeField] protected Material[] levelItemMat;
    public Material[] LevelItemMat => levelItemMat;
    

    private SimpleMenuService simpleMenuService;
    private BuyPanel buyPanel;
    
    public string ItemName => itemName;
    public string ItemDescription => itemDescription;
    public int MaxLevels => maxLevels;
    public int CurrentLevel => currentLevel;

    public void Awake()
    {
        simpleMenuService = FindObjectOfType<SimpleMenuService>();
        buyPanel = FindObjectOfType<BuyPanel>();
    }

    public void UpgradeItemLevel()
    {
        currentLevel += 1;
        
        if(!ignoreItemMesh)
            itemMesh.material = levelItemMat[currentLevel];
    }

    private void OpenBuyPanel()
    {
        buyPanel.SetNewBuyPanelValues(this);
        simpleMenuService.OpenMenu(1);
    }
    
    public abstract void BuyItem();

    public virtual void OnPointerDown(PointerEventData eventData){OpenBuyPanel();}

    public virtual void OnPointerEnter(PointerEventData eventData){}

    public virtual void OnPointerExit(PointerEventData eventData){}
}
