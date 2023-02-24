using System;
using UnityEngine;

public class GlobalFactoryLineAnimation : MonoBehaviour
{
    [SerializeField] private GlobalFactoryLine globalFactoryLine;
    [SerializeField] private float factoryLineMovementMultiplier = 4;
    [SerializeField] private float factoryLineSpeed = 2;

    [Space] 
    
    [SerializeField] private FactoryLineFragmentResourceAnimation[] linesResourceAnimations;
    [SerializeField] private float startLinesResourceAnimationSpeed;
    
    [Space]
    
    [SerializeField] private Material factoryLineMat;
    private static readonly int LineMovement = Shader.PropertyToID("_LineMovement");

    private void Start()
    {
        SetStartLinesResourceAnimationSpeed();
        void SetStartLinesResourceAnimationSpeed()
        {
            foreach (var animationResource in linesResourceAnimations)
                animationResource.SetNewAnimationSpeed(startLinesResourceAnimationSpeed);
        }
    }

    private void Update()
    {
        FactoryLinesAnimatedMovement();
        void FactoryLinesAnimatedMovement()
        {
            var actualFactoryLineMovement = globalFactoryLine.CurrentFactoryLineMovement * factoryLineMovementMultiplier;
            var currentFactoryLineMovement = factoryLineMat.GetVector(LineMovement).x;

            var timeStep = Time.deltaTime * factoryLineSpeed;
            var animatedFactoryLineMovement = 
                Mathf.Lerp(currentFactoryLineMovement, actualFactoryLineMovement,timeStep);
            
            factoryLineMat.SetVector(LineMovement,
                new Vector4(animatedFactoryLineMovement,0,0,0));
        }
    }
}
