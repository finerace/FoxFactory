using System;
using System.Collections.Generic;
using UnityEngine;

public class Storehouse : ResourceInput
{
    [SerializeField] private PlayerMoneyService playerMoneyService;
    [SerializeField] private int maxResourceCount = 30;
    [SerializeField] private int resourceQualityUp = 0;
    
    private Queue<int> resourceStorehouse = new Queue<int>();

    [Space] 
    [SerializeField] private int excessPriceDivider;
    
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
        resource.UpResourceQuality(resourceQualityUp);
        
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
                print(resource.ResourceQuality + "  " + excessPriceDivider);

                playerMoneyService.MoneyCount += resource.ResourceQuality / excessPriceDivider;
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

    public void SetResourceQualityUp(int qualityUp)
    {
        if (qualityUp < 0)
            throw new Exception("Улучшение качества ресурса не может быть отрицательным!");

        resourceQualityUp = qualityUp;
    }
    
}
