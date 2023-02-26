using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceCourier : MonoBehaviour
{
    [SerializeField] private PlayerMoneyService playerMoneyService;
    [SerializeField] private Storehouse mainStorehouse;

    [Space]
    
    [SerializeField] private int courierMaxCapacity = 30;
    [SerializeField] private float courierRepeatTime = 30;
    
    [Space] 
    
    [SerializeField] private List<int> resources;

    [Space]
    
    [SerializeField] private SimpleAnimator courierAnimator;
    
    private event Action<int> onSellResourceEvent;
    public event Action<int> OnSellResourceEvent
    {
        add => onSellResourceEvent += value ?? throw new NullReferenceException();

        remove => onSellResourceEvent -= value ?? throw new NullReferenceException();
    }
    
    private void Start()
    {
        StartCoroutine(CourierComingTimer());
    }

    private IEnumerator CourierComingTimer()
    {
        YieldInstruction courierCityTimeWait = new WaitForSeconds(courierRepeatTime * 0.40f);
        YieldInstruction courierWalkToStorehouseTimeWait = new WaitForSeconds(courierRepeatTime * 0.30f);
        YieldInstruction courierWalkToCityTimeWait = new WaitForSeconds(courierRepeatTime * 0.20f);

        
        while (true)
        {
            courierAnimator.state = 1;

            yield return courierCityTimeWait;

            courierAnimator.movingObject.position = courierAnimator.positions[2];
            courierAnimator.state = 0;

            yield return courierWalkToStorehouseTimeWait;
            
            yield return StartCoroutine(CollectResources());
            
            yield return courierWalkToCityTimeWait;
            
            SellAllResources();
        }
    }

    private void SellAllResources()
    {
        var resultCurrency = 0;

        foreach (var resourceQuality in resources)
            resultCurrency += resourceQuality;
        
        playerMoneyService.MoneyCount += (int)resultCurrency;
        
        onSellResourceEvent?.Invoke(resultCurrency);
    }
    
    private IEnumerator CollectResources()
    {
        YieldInstruction oneCollectWaitTime = new WaitForSeconds(0.05f);
        
        var maxResourceCapacity = courierMaxCapacity - Mathf.Abs(mainStorehouse.CurrentResourceCount - courierMaxCapacity);

        for (int i = 0; i < maxResourceCapacity; i++)
        {
            resources.Add(mainStorehouse.GetOneResource());

            yield return oneCollectWaitTime;
        }
    }
}
