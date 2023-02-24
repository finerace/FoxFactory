using System;
using System.Collections.Generic;
using UnityEngine;

public class FactoryLineFragmentResourceAnimation : MonoBehaviour
{
    [SerializeField] private FactoryLineFragment factoryLineFragment;
    [SerializeField] private float animationSpeed;
    
    private Dictionary<FoxResource, float> resourceAnimatedProgressOnFactoryLine = new Dictionary<FoxResource, float>();
    
    private void Start()
    {
        factoryLineFragment.OnInputResourceEvent += AddResource;
        factoryLineFragment.OnOutputResourceEvent += RemoveResource;
    }

    private void Update()
    {
        MoveResource();
    }

    private void MoveResource()
    {
        foreach (var foxResource in factoryLineFragment.ResourcesOnFactoryLine)
        {
            var foxResourceT = foxResource.Key;
            
            var actualResourceProgress = foxResource.Value;
            var animateResourceProgress = resourceAnimatedProgressOnFactoryLine[foxResource.Key];


            var timeStep = Time.deltaTime * animationSpeed;
            var resultAnimatedProgress = Mathf.Lerp(animateResourceProgress, actualResourceProgress,timeStep);

            foxResourceT.ResourceT.position =
                FactoryLineFragment.GetLinePos(factoryLineFragment, resultAnimatedProgress);

            resourceAnimatedProgressOnFactoryLine[foxResource.Key] = resultAnimatedProgress;
        }
    }
    
    private void AddResource(FoxResource foxResource)
    {
        resourceAnimatedProgressOnFactoryLine.Add(foxResource,0);
    }
    
    private void RemoveResource(FoxResource foxResource)
    {
        resourceAnimatedProgressOnFactoryLine.Remove(foxResource);
    }

    public void SetNewAnimationSpeed(float speed)
    {
        if (speed < 0)
            throw new Exception("Скорость анимации конвейера не может быть отрицательной.");

        animationSpeed = speed;
    }
}
