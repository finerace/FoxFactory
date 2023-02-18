using UnityEngine;

public class FoxResource : MonoBehaviour
{
    [SerializeField] private Transform resourceT;
    [SerializeField] private MeshRenderer resourceMesh;

    public Transform ResourceT => resourceT;
    
    public void SetNewResourceMaterial(Material newMat)
    {
        resourceMesh.material = newMat;
    }
}
