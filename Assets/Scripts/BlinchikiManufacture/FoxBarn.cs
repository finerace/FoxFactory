using System;
using UnityEngine;

public class FoxBarn : MonoBehaviour
{
    [SerializeField] private GlobalFactoryLine globalFactoryLine;

    [Space] 
    
    [SerializeField] private float resourceSpawnFactor = 0.25f;
    [SerializeField] private int resourceStartQuality = 0;
    
    private float oldFactoryLineMovement = 0;
    
    [Space]
    
    [SerializeField] private ResourceInput startFactoryLine;
    [SerializeField] private GameObject resourcePrefab;


    private void Start()
    {
        globalFactoryLine.OnFactoryLineMoveEvent += CheckForSpawn;
    }

    private void CheckForSpawn(float currentFactoryLineMovement)
    {
        var factoryLineSpawnFactor = (oldFactoryLineMovement + resourceSpawnFactor) - currentFactoryLineMovement;

        if (factoryLineSpawnFactor <= 0)
        {
            oldFactoryLineMovement = currentFactoryLineMovement;

            SpawnResource(factoryLineSpawnFactor+resourceSpawnFactor);
        }
    }

    private void SpawnResource(float inputPower)
    {
        var newResource = 
            Instantiate(resourcePrefab,transform.position,Quaternion.identity).GetComponent<FoxResource>();
        
        newResource.UpResourceQuality(resourceStartQuality);
        startFactoryLine.Input(newResource,inputPower);
        
        if(inputPower + resourceSpawnFactor <= 0)
            SpawnResource(inputPower+resourceSpawnFactor);
    }
    
    public void SetResourceSpawnRate(float newSpawnRate)
    {
        if (newSpawnRate <= 0)
            throw new Exception("spawnRate не может быть отрицательным или нулевым.");

        resourceSpawnFactor = newSpawnRate;
    }

    public void SetResourceStartQuality(int startQuality)
    {
        if (startQuality < 0)
            throw new Exception("Стартовое значение качества не может быть меньше нуля!");

        resourceStartQuality = startQuality;
    }
}
