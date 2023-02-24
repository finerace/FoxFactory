using System;
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

    public void UpResourceQuality(float quality)
    {
        if(quality <= 0)
            throw new Exception("Улучшение качества не может быть меньше или равно нулю. ПЕРЕДЕЛЫВАЙ!");
        
        resourceQuality += quality;
    }

}
