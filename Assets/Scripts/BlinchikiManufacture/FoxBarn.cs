using System;
using UnityEngine;

public class FoxBarn : MonoBehaviour
{
    [SerializeField] private GlobalFactoryLine globalFactoryLine;

    [Space] 
    
    [SerializeField] private float resourceSpawnFactor = 0.25f;

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

            SpawnResource();
        }
    }

    private void SpawnResource()
    {
        var newResource = 
            Instantiate(resourcePrefab,transform.position,Quaternion.identity).GetComponent<FoxResource>();
        
        startFactoryLine.Input(newResource,0);
    }
    
    public void SetResourceSpawnRate(float newSpawnRate)
    {
        if (newSpawnRate <= 0)
            throw new Exception("spawnRate не может быть отрицательным или нулевым.");

        resourceSpawnFactor = newSpawnRate;
    }
}
