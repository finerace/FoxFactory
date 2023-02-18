using UnityEngine;

public class EndShop : ResourceInput
{
    [SerializeField] private PlayerMoneyService playerMoneyService;
    
    public override void Input(FoxResource resource)
    {
        Destroy(resource.gameObject);
        playerMoneyService.MoneyCount += 1;
    }
}
