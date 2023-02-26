using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonsAnimationScaling : MonoBehaviour,IPointerEnterHandler,IPointerExitHandler
{
    private Transform buttonT;
    [SerializeField] private float scaling;
    [SerializeField] private float scalingSpeed;
    private Vector3 startScale;

    private bool mouseOnButton;

    private void Awake()
    {
        buttonT = transform;

        startScale = buttonT.localScale;
    }

    private void Update()
    {
        ButtonScaleAnimation();
    }

    private void ButtonScaleAnimation()
    {
        var scaleFactor = 1f;

        if (mouseOnButton)
            scaleFactor = scaling;

        var timeStep = Time.deltaTime * scalingSpeed;
        var currentScale = buttonT.localScale;

        currentScale = Vector3.Lerp(currentScale, startScale * scaleFactor, timeStep);

        buttonT.localScale = currentScale;
    }
    
    public void OnPointerEnter(PointerEventData eventData)
    {
        mouseOnButton = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        mouseOnButton = false;
    }
}
