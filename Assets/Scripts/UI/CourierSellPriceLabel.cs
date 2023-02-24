using System;
using System.Collections;
using TMPro;
using UnityEngine;

public class CourierSellPriceLabel : MonoBehaviour
{
    [SerializeField] private ResourceCourier courier;
    [SerializeField] private Transform sellPriceLabelT;
    [SerializeField] private TMP_Text sellPriceLabel;

    [Space] 
    
    [SerializeField] private float animationSpeed = 2;
    [SerializeField] private Vector3 startAnimPos;
    [SerializeField] private Vector3 endAnimPos;

    [SerializeField] private bool isAnimationWork;


    private void Start()
    {
        courier.OnSellResourceEvent += StartAnimation;
    }

    private void Update()
    {
        if (isAnimationWork)
        {
            var timeStep = Time.deltaTime * animationSpeed;
            
            sellPriceLabelT.position = Vector3.MoveTowards(sellPriceLabelT.position, endAnimPos,timeStep);
            
            var oldLabelColor = sellPriceLabel.color;
            oldLabelColor.a = Mathf.MoveTowards(oldLabelColor.a,0,timeStep);
            sellPriceLabel.color = oldLabelColor;

            if (oldLabelColor.a == 0)
                isAnimationWork = false;
        }
        
    }
    
    private void StartAnimation(int sellPrice)
    {
        isAnimationWork = true;
        sellPriceLabelT.position = startAnimPos;

        sellPriceLabel.text = $"+{sellPrice}$";
        
        var oldLabelColor = sellPriceLabel.color;
        oldLabelColor.a = 1;
        sellPriceLabel.color = oldLabelColor;
    }

}
