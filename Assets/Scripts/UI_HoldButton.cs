using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;
public class UI_HoldButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public UnityEvent OnHold;
    bool isHolding;
    public void OnPointerDown(PointerEventData eventData)
    {
        isHolding = true;
    }
    public void OnPointerUp(PointerEventData eventData)
    {
        isHolding = false;
    }
    void Update()
    {
        if (isHolding)
        {
            OnHold.Invoke();
        }
    }
}