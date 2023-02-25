using System;
using UnityEngine;

public class GlobalFactoryLine : MonoBehaviour
{
    [SerializeField] private float factoryLineClickSpeed;
    [SerializeField] private float currentFactoryLineMovement;
    
    [SerializeField] private FactoryLineFragment[] factoryLineFragments;
    
    public float CurrentFactoryLineMovement => currentFactoryLineMovement;

    private event Action<float> onFactoryLineMoveEvent;
    public event Action<float> OnFactoryLineMoveEvent
    {
        add => onFactoryLineMoveEvent += value ?? throw new NullReferenceException();
        
        remove => onFactoryLineMoveEvent -= value ?? throw new NullReferenceException();
    }
    
    public void OnClickMoveFactoryLine()
    {
        MoveFactoryLine(factoryLineClickSpeed);
    }
    
    public void MoveFactoryLine(float moveStep)
    {
        currentFactoryLineMovement += moveStep;
        
        MoveAllFactoryLineFragments();
        void MoveAllFactoryLineFragments()
        {
            foreach (var factoryLineFragment in factoryLineFragments)
            {
                factoryLineFragment.MoveFactoryLine(moveStep);
            }
        }

        onFactoryLineMoveEvent?.Invoke(currentFactoryLineMovement);
    }

    public void SetNewClickPower(float clickPower)
    {
        if (clickPower < 0)
            throw new Exception("клики в долг не берём");

        factoryLineClickSpeed = clickPower;
    }
}