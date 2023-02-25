using System;
using System.Collections.Generic;
using UnityEngine;

public class Storehouse : ResourceInput
{
    [SerializeField] private PlayerMoneyService playerMoneyService;
    [SerializeField] private int maxResourceCount = 30;

    private Queue<int> resourceStorehouse = new Queue<int>();

    [Space] 
    [SerializeField] private int excessPriceMultiplier;
    
    private event Action<int> onBlicnhikiCountChangeEvent;
    public event Action<int> OnBlicnhikiCountChangeEvent
    {
        add => onBlicnhikiCountChangeEvent += value ?? throw new NullReferenceException();

        remove => onBlicnhikiCountChangeEvent -= value ?? throw new NullReferenceException();
    }

    public int MaxResourceCount => maxResourceCount;
    public int CurrentResourceCount => resourceStorehouse.Count;

    private void Start()
    {
        onBlicnhikiCountChangeEvent?.Invoke(resourceStorehouse.Count);
    }

    public override void Input(FoxResource resource,float resourceMoveForce)
    {
        if (resourceStorehouse.Count < maxResourceCount)
        {
            AddNewBlinchikToStorehouse();
            void AddNewBlinchikToStorehouse()
            {
                resourceStorehouse.Enqueue(resource.ResourceQuality);
                
                onBlicnhikiCountChangeEvent?.Invoke(resourceStorehouse.Count);
            }
        }
        else
        {
            SellExcess();
            void SellExcess()
            {
                playerMoneyService.MoneyCount += resource.ResourceQuality / excessPriceMultiplier;
            }
        }
        
        Destroy(resource.gameObject);
    }

    public int GetOneResource()
    {
        if (resourceStorehouse.Count <= 0)
            throw new Exception("Ресурсов больше нет!");

        var result = resourceStorehouse.Dequeue();
        
        onBlicnhikiCountChangeEvent?.Invoke(CurrentResourceCount);
        return result;
    }

    public void SetNewMaxResourceCount(int newMaxResource)
    {
        if (newMaxResource <= 0)
            throw new Exception("Нельзя делать нулевое или отрицательное количество вместимости");

        maxResourceCount = newMaxResource;
        
        onBlicnhikiCountChangeEvent?.Invoke(CurrentResourceCount);
    }
    
}
