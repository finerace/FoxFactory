using System;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;

public class GlobalFactoryLine : MonoBehaviour
{
    [SerializeField] private float factoryLineClickSpeed;
    private float currentFactoryLineMovement;
    
    [SerializeField] private FactoryLineFragment[] factoryLineFragments;
    
    public float CurrentFactoryLineMovement => currentFactoryLineMovement;

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
    }

    public void SetNewClickPower(float clickPower)
    {
        if (clickPower < 0)
            throw new Exception("клики в долг не берём");

        factoryLineClickSpeed = clickPower;
    }

}