using System;
using UnityEngine;

public class PlayerMoneyService : MonoBehaviour
{
    [SerializeField] private int moneyCount;
    
    public int MoneyCount
    {
        get => moneyCount;

        set
        {
            if (value < 0)
                throw new Exception("ты чего такое выдумал, тут в долг брать нельзя, а ну циферки свои подправь!");
            
            moneyCount = value;
            
            onMoneyCountChange?.Invoke(moneyCount);
        }
    }

    private event Action<int> onMoneyCountChange;
    public event Action<int> OnMoneyCountChange
    {
        add => onMoneyCountChange += value ?? throw new NullReferenceException(); 
        
        remove => onMoneyCountChange -= value ?? throw new NullReferenceException();
    }


    private void Start()
    {
        onMoneyCountChange?.Invoke(moneyCount);
    }

    private void Update()
    {
        //onMoneyCountChange?.Invoke(moneyCount);
    }
}
