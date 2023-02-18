using UnityEngine;

public class FoxBarn : MonoBehaviour
{
    [SerializeField] private int clicksCountToGenerateWheat = 4;
    [SerializeField] private int currentClicksCount = 0;
    
    [SerializeField] private ResourceInput startFactoryLine;
    [SerializeField] private GameObject wheatResourcePrefab;
    [Space] 
    
    [SerializeField] private Material factoryLineMat;
    [SerializeField] private float factoryLineMovementMultiplier = 2;
    private static readonly int LineMovement = Shader.PropertyToID("_LineMovement");

    public void ClickManufacture()
    {
        currentClicksCount++;
        
        if (currentClicksCount >= clicksCountToGenerateWheat)
        {
            currentClicksCount = 0;
            
            var foxResource = Instantiate(wheatResourcePrefab).GetComponent<FoxResource>();
            startFactoryLine.Input(foxResource);
        }

        FactoryLinesMovement();
        void FactoryLinesMovement()
        {
            var currentFactoryLineMovement = factoryLineMat.GetVector(LineMovement).x;
            factoryLineMat.SetVector(LineMovement,
                new Vector4(currentFactoryLineMovement + FactoryLine.Speed*factoryLineMovementMultiplier,0,0,0));
        }
        
    }
}
