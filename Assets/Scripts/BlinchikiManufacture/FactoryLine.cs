using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class FactoryLine : ResourceInput
{
    private static float speed = 0.1f;
    public static float Speed => speed;
    
    [SerializeField] private Transform factoryLineT;
    [SerializeField] private ResourceInput resourceOutput;
    [SerializeField] private float lineWidth = 3;
    
    private Dictionary<FoxResource, float> resourcesOnFactoryLine = new Dictionary<FoxResource, float>();

    public override void Input(FoxResource resource)
    {
        resourcesOnFactoryLine.Add(resource,0);
        
        resource.ResourceT.position = GetLinePos(0);
        resource.ResourceT.rotation = factoryLineT.rotation;
    }

    public void MoveFactoryLine()
    {
        var resourcesToOutput = new List<FoxResource>();

        MoveResourcesOnLine();
        void MoveResourcesOnLine()
        {
            var foxResourceToAddProgress = resourcesOnFactoryLine.Keys.ToList();

            foreach (var foxResource in foxResourceToAddProgress)
            {
                resourcesOnFactoryLine[foxResource] += speed;
                var lineProgress = resourcesOnFactoryLine[foxResource];

                if (lineProgress > 1)
                    resourcesToOutput.Add(foxResource);

                foxResource.ResourceT.position = GetLinePos(lineProgress);
            }
        }

        OutputResources();
        void OutputResources()
        {
            foreach (var foxResource in resourcesToOutput)
            {
                resourcesOnFactoryLine.Remove(foxResource);
                resourceOutput.Input(foxResource);
            }
        }
    }
    
    private Vector3 GetLinePos(float lineProgress)
    {
        if (lineProgress > 1)
            lineProgress = 1;
        else if (lineProgress < 0)
            lineProgress = 0;
        
        var localLineWidth = factoryLineT.localScale.x;
        var lineLength = localLineWidth * lineWidth;

        var resultPos = new Vector3();
        
        var lineForwardVector = -factoryLineT.right;
        resultPos = lineForwardVector * (lineLength * lineProgress);
        resultPos -= lineForwardVector * (lineLength / 2);
        
        resultPos += factoryLineT.position + factoryLineT.up * 0.05f;
        
        return resultPos;
    }
}
