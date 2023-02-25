using System;
using System.ComponentModel.Design;
using TMPro;
using UnityEngine;

public class PlayerMoneyService : MonoBehaviour
{
    [SerializeField] private float moneyCount;
    
    public float MoneyCount
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

    private event Action<float> onMoneyCountChange;
    public event Action<float> OnMoneyCountChange
    {
        add => onMoneyCountChange += value ?? throw new NullReferenceException(); 
        
        remove => onMoneyCountChange -= value ?? throw new NullReferenceException();
    }


    private void Start()
    {
        onMoneyCountChange?.Invoke(moneyCount);
    }
}
