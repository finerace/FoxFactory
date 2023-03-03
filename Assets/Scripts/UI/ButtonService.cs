using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class ButtonService : MonoBehaviour,IPointerClickHandler
{
    [SerializeField] private UnityEvent onButtonClick;
    

    public void OnPointerClick(PointerEventData eventData)
    {
        onButtonClick.Invoke();
    }
    
}