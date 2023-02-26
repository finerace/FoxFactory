using System;
using UnityEngine;

public class FoxResource : MonoBehaviour
{
    [SerializeField] private Transform resourceT;
    [SerializeField] private MeshRenderer resourceMesh;
    [SerializeField] private int resourceQuality = 1;

    public int ResourceQuality => resourceQuality;
    public Transform ResourceT => resourceT;
    
    public void SetNewResourceMaterial(Material newMat)
    {
        resourceMesh.material = newMat;
    }

    public void UpResourceQuality(int quality)
    {
        if(quality < 0)
            throw new Exception("Улучшение качества не может быть меньше нуля. ПЕРЕДЕЛЫВАЙ");
        
        resourceQuality += quality;
    }

}
