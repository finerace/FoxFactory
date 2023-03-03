using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using UnityEngine;

public class ShopItemMeshAnimationService : MonoBehaviour
{
    [SerializeField] private ShopItem meshShopItem;
    [SerializeField] private Transform meshT;

    [Space] 
    
    [SerializeField] private float animationSpeed;
    [SerializeField] private float canBuyMeshBlopCooldown = 1;
    
    
    [Space]
    
    [SerializeField] private float hightTargetValueMultiplier;
    private float defaultHight;
    private float currentHightTargetValue;
    
    
    [SerializeField] private float widthTargetValueMultiplier; 
    private float defaultWidth;
    private float currentWidthTargetValue;

    private void Start()
    {
        meshShopItem.OnShopItemClick += OnClickWidthHightAnimation;
        
        SetFields();
        void SetFields()
        {
            if (meshT == null)
                meshT = transform;

            var meshLocalScale = meshT.localScale;
            defaultWidth = meshLocalScale.x;
            defaultHight = meshLocalScale.z;

            currentHightTargetValue = 1;
            currentWidthTargetValue = 1;
        }

        StartCoroutine(CanBuyBlopTimer());
    }

    private void Update()
    {
        AnimationProcess();
        void AnimationProcess()
        {
            var shopItemLocalScale = meshT.localScale;
            var timeStep = Time.deltaTime * animationSpeed;
            
            shopItemLocalScale.x = 
                Mathf.Lerp(shopItemLocalScale.x, currentWidthTargetValue * defaultWidth, timeStep);

            shopItemLocalScale.z =
                Mathf.Lerp(shopItemLocalScale.z, currentHightTargetValue * defaultHight, timeStep);

            meshT.localScale = shopItemLocalScale;
            
            currentHightTargetValue = Mathf.Lerp(currentHightTargetValue,1,timeStep);
            currentWidthTargetValue = Mathf.Lerp(currentWidthTargetValue, 1, timeStep);
        }
    }

    private void OnClickWidthHightAnimation()
    {
        var hightChange = 0.1f * hightTargetValueMultiplier;
        var widthChange = -0.1f * widthTargetValueMultiplier;

        currentHightTargetValue += hightChange;
        currentWidthTargetValue += widthChange;
    }

    private void OnCanBuyBlopAnimation()
    {
        ChangeHightWidth(0.05f,-0.05f);    
    }

    private void ChangeHightWidth(float hightChange, float widthChange)
    {
        hightChange *= hightTargetValueMultiplier;
        widthChange *= widthTargetValueMultiplier;

        currentHightTargetValue += hightChange;
        currentWidthTargetValue += widthChange;
    }

    private IEnumerator CanBuyBlopTimer()
    {
        var wait = new WaitForSeconds(canBuyMeshBlopCooldown);

        while (true)
        {
            yield return wait;
            
            if(meshShopItem.IsItemCanBuy)
                OnCanBuyBlopAnimation();
        }
    }
    
}
