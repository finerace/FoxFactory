using UnityEngine;

public class EndGameCheckService : MonoBehaviour
{
    [SerializeField] private PlayerMoneyService playerMoneyService;
    [SerializeField] private Transform endGameButton;

    [Space] 
    
    [SerializeField] private int currencyToEndGame;
    private bool isEndGameButtonSpawned = false;
    
    private void Awake()
    {
        playerMoneyService.OnMoneyCountChange += CheckForEndGame;
    }

    private void CheckForEndGame(int currency)
    {
        if(isEndGameButtonSpawned)
            return;

        if (currency >= currencyToEndGame)
        {
            endGameButton.gameObject.SetActive(true);
            isEndGameButtonSpawned = true;
        }
    }
    
}
