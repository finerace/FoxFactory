using System;
using System.Collections;
using UnityEngine;

public class GlobalFactoryLineAutoMovement : MonoBehaviour
{
    [SerializeField] private GlobalFactoryLine globalFactoryLine;
    [SerializeField] private float autoMovementPower = 0;
    public float AutoMovementPower => autoMovementPower;

    // private event Action<float> onSetNewAutoMovementPower;
    // public event Action<float> OnSetNewAutoMovementPower
    // {
    //     add => onSetNewAutoMovementPower += value ?? throw new NullReferenceException();
    //
    //     remove => onSetNewAutoMovementPower -= value ?? throw new NullReferenceException();
    // }

    [Space] 
    
    private readonly float updateTime = 0.1f;
    
    private void Start()
    {
        StartCoroutine(AutoMovementUpdater());
    }

    IEnumerator AutoMovementUpdater()
    {
        var waitTime = new WaitForSeconds(updateTime);

        const float powerSmooth = 0.01f;
        
        while (true)
        {
            yield return waitTime;

            var moveStep = autoMovementPower * powerSmooth ;
            
            globalFactoryLine.MoveFactoryLine(moveStep);
        }
        
    }
    
    public void SetAutoMovementPower(float power)
    {
        if (power < 0)
            throw new Exception("Мощность авто-движение не может быть отрицательной, такие приколы не приветствуются в нашем обществе.");

        autoMovementPower = power;
        
        //onSetNewAutoMovementPower?.Invoke(autoMovementPower);
    }
    
}
