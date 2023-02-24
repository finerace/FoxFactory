using UnityEngine;

public class FoxBarn : MonoBehaviour
{
    [SerializeField] private int clicksCountToGenerateWheat = 4;
    [SerializeField] private int currentClicksCount = 0;
    
    [SerializeField] private ResourceInput startFactoryLine;
    [SerializeField] private GameObject wheatResourcePrefab;

    public void ClickManufacture()
    {
        currentClicksCount++;
        
        if (currentClicksCount >= clicksCountToGenerateWheat)
        {
            currentClicksCount = 0;
            
            var foxResource = Instantiate(wheatResourcePrefab).GetComponent<FoxResource>();
            startFactoryLine.Input(foxResource,0);
        }
    }
}
