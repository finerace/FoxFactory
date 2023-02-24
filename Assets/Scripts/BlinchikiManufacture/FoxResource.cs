using UnityEngine;

public class FoxResource : MonoBehaviour
{
    [SerializeField] private Transform resourceT;
    [SerializeField] private MeshRenderer resourceMesh;
    [SerializeField] private float resourceQuality = 1;

    public float ResourceQuality => resourceQuality;
    
    public Transform ResourceT => resourceT;
    
    public void SetNewResourceMaterial(Material newMat)
    {
        resourceMesh.material = newMat;
    }

    public void UpResourceQuality(int processingQuality)
    {
        if(processingQuality <= 0)
            return;

        const float processingQualityFactor = 0.1f;

        resourceQuality += processingQuality * processingQualityFactor;
    }

}
