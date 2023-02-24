using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class FactoryLineFragment : ResourceInput
{
    [SerializeField] private Transform factoryLineT;
    [SerializeField] private ResourceInput resourceOutput;

    [SerializeField] private float lineWidth = 1;
    [SerializeField] private float visualLineWidth = 12;

    public Transform FactoryLineT => factoryLineT;
    public float LineWidth => lineWidth;
    public float VisualLineWidth => visualLineWidth;


    private Dictionary<FoxResource, float> resourcesOnFactoryLine = new Dictionary<FoxResource, float>();
    public Dictionary<FoxResource, float> ResourcesOnFactoryLine => resourcesOnFactoryLine;
    
    private event Action<FoxResource> onInputResourceEvent;
    public event Action<FoxResource> OnInputResourceEvent
    {
        add => onInputResourceEvent += value ?? throw new NullReferenceException();

        remove => onInputResourceEvent -= value ?? throw new NullReferenceException();
    }
    
    private event Action<FoxResource> onOutputResourceEvent;
    public event Action<FoxResource> OnOutputResourceEvent
    {
        add => onOutputResourceEvent += value ?? throw new NullReferenceException();

        remove => onOutputResourceEvent -= value ?? throw new NullReferenceException();
    }
    
    public override void Input(FoxResource resource,float resourceMoveForce)
    {
        resourcesOnFactoryLine.Add(resource,resourceMoveForce);
        
        resource.ResourceT.position = GetLinePos(this,0);
        resource.ResourceT.rotation = factoryLineT.rotation;

        onInputResourceEvent?.Invoke(resource);
    }
    
    public void MoveFactoryLine(float moveStep)
    {
        var resourcesToOutput = new Dictionary<FoxResource,float>();

        MoveResourcesOnLine();
        void MoveResourcesOnLine()
        {
            var foxResourceToAddProgress = resourcesOnFactoryLine.Keys.ToList();

            foreach (var foxResource in foxResourceToAddProgress)
            {
                resourcesOnFactoryLine[foxResource] += moveStep;
                var lineProgress = resourcesOnFactoryLine[foxResource];

                if (lineProgress >= lineWidth)
                {
                    var resourceMoveForce = lineProgress - lineWidth;
                    
                    resourcesToOutput.Add(foxResource,resourceMoveForce);
                }
            }
        }

        ReleaseResourcesToOutput();
        void ReleaseResourcesToOutput()
        {
            foreach (var foxResource in resourcesToOutput)
            {
                resourcesOnFactoryLine.Remove(foxResource.Key);
                resourceOutput.Input(foxResource.Key,foxResource.Value);
                
                onOutputResourceEvent?.Invoke(foxResource.Key);
            }
        }
    }
    
    public static Vector3 GetLinePos(FactoryLineFragment factoryLineFragment,float lineProgress)
    {
        if (lineProgress > factoryLineFragment.LineWidth)
            lineProgress = factoryLineFragment.LineWidth;
        else if (lineProgress < 0)
            lineProgress = 0;
        
        var localLineWidth = factoryLineFragment.FactoryLineT.localScale.x;
        var lineLength = localLineWidth * factoryLineFragment.VisualLineWidth;

        var resultPos = new Vector3();
        
        var lineForwardVector = -factoryLineFragment.FactoryLineT.right;
        resultPos = lineForwardVector * (lineLength * lineProgress);
        resultPos -= lineForwardVector * (lineLength / 2);
        
        resultPos += factoryLineFragment.FactoryLineT.position + factoryLineFragment.FactoryLineT.up * 0.05f;
        
        return resultPos;
    }
}
