using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class PointerHandler : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public Action<PointerEventData> onPointerDown;
    public Action<PointerEventData> onPointerUp;
    public void OnPointerDown(PointerEventData pointerEventData) => onPointerDown?.Invoke(pointerEventData);
    public void OnPointerUp(PointerEventData pointerEventData) => onPointerUp?.Invoke(pointerEventData);
}
