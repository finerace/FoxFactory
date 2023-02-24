using System.Security.Cryptography.X509Certificates;
using UnityEngine;

public class FoxFactory : ResourceInput
{
    [SerializeField] private int factoryLevel = 0;
    [SerializeField] private MeshRenderer factoryMesh;
    [Space]
    [SerializeField] private ResourceInput resourceOutput;
    [SerializeField] private Material foxResourceNewMat;
    
    public override void Input(FoxResource resource,float resourceMoveForce)
    {
        resource.UpResourceQuality(factoryLevel);

        resource.SetNewResourceMaterial(foxResourceNewMat);
        resourceOutput.Input(resource,resourceMoveForce);
    }

    public void UpgradeFactoryLevel()
    {
        factoryLevel += 1;
    }

}
