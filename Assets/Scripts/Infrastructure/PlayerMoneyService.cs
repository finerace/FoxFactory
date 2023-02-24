using System;
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
            UpdateMoneyLabel();
        }
    }
    
    [SerializeField] private TMP_Text moneyLabel;
    [SerializeField] private string moneyPreText;

    private void Start()
    {
        UpdateMoneyLabel();
    }

    private void UpdateMoneyLabel()
    {
        moneyLabel.text = $"{moneyPreText}{(int)moneyCount}";
    }
    
}
