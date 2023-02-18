using UnityEngine;

public class FoxFactory : ResourceInput
{
    [SerializeField] private ResourceInput resourceOutput;
    [SerializeField] private Material foxResourceNewMat;
    
    public override void Input(FoxResource resource)
    {
        resource.SetNewResourceMaterial(foxResourceNewMat);
        resourceOutput.Input(resource);
    }
}
