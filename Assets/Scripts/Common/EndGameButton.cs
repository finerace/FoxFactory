using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndGameButton : MonoBehaviour,IPointerClickHandler
{
    [SerializeField] private PlayerMoneyService playerMoneyService;
    [SerializeField] private int currencyToWin = 3500;
    
    [Space]

    [SerializeField] private Image buttonImage;
    [SerializeField] private float colorChangeSpeed = 5;
    [SerializeField] private Color disabledColor;
    [SerializeField] private Color enabledColor;
    
    private bool isButtonEnabled;

    private void Start()
    {
        playerMoneyService.OnMoneyCountChange += CheckCurrencyForWin;
    }

    private void Update()
    { 
        ChangeButtonColor();
        void ChangeButtonColor()
        {
            var targetColor = disabledColor;

            if (isButtonEnabled)
                targetColor = enabledColor;

            var timeStep = Time.deltaTime * colorChangeSpeed;

            var buttonColor = buttonImage.color;
            buttonImage.color = Color.Lerp(buttonColor, targetColor, timeStep);
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if(!isButtonEnabled)
            return;

        SceneManager.LoadScene(2);
    }

    private void CheckCurrencyForWin(int currency)
    {
        isButtonEnabled = currency >= currencyToWin;
    }
    
}
