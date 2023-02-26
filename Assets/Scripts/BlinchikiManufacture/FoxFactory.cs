using System;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;

public class FoxFactory : ResourceInput
{
    [SerializeField] private int resourceQualityFactor = 0;
    [SerializeField] private MeshRenderer factoryMesh;
    [Space]
    [SerializeField] private ResourceInput resourceOutput;
    [SerializeField] private Material foxResourceNewMat;

    private event Action resourceInputEvent;
    
    public event Action ResourceInputEvent
    {
        add => resourceInputEvent += value ?? throw new NullReferenceException();
        remove => resourceInputEvent += value ?? throw new NullReferenceException();
    }

    public override void Input(FoxResource resource,float resourceMoveForce)
    {
        resource.UpResourceQuality(resourceQualityFactor);

        resource.SetNewResourceMaterial(foxResourceNewMat);
        resourceOutput.Input(resource,resourceMoveForce);
        
        resourceInputEvent?.Invoke();
    }

    public void SetResourceQualityFactor(int qualityFactor)
    {
        if (qualityFactor <= 0)
            throw new Exception("Завод не может ухудшать или не изменять качество ресурса. ПЕРЕДЕЛЫВАЙ!");

        resourceQualityFactor = qualityFactor;
    }

}
