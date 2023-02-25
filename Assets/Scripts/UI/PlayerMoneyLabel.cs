using TMPro;
using UnityEngine;

public class PlayerMoneyLabel : MonoBehaviour
{

    [SerializeField] private PlayerMoneyService playerMoneyService;
    [SerializeField] private TMP_Text moneyCountLabel;
    
    [Space]
    
    [SerializeField] private string moneyPreText;

    private void Awake()
    {
        playerMoneyService.OnMoneyCountChange += UpdateMoneyLabel;
    }

    private void UpdateMoneyLabel(float moneyCount)
    {
        moneyCountLabel.text = $"{moneyPreText}{(int)moneyCount}";
    }
    
}
