using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Popup : MonoBehaviour
{

    public Action onClose;
    public Action onOpen;

    [SerializeField] protected float openCloseDuration = .5f;
    [SerializeField] protected CanvasGroup canvasGroup;

    public virtual void Open(Action callback = null)
    {
        canvasGroup.alpha = 0;

        gameObject.SetActive(true);

        DOVirtual.Float(0, 1, openCloseDuration, (value) =>
            {
                canvasGroup.alpha = value;
            })
            .OnComplete(() =>
            {
                onOpen?.Invoke();
                callback?.Invoke();
            });
    }

    public virtual void Close(Action callback = null)
    {
        canvasGroup.alpha = 1;

        gameObject.SetActive(true);

        DOVirtual.Float(1, 0, openCloseDuration, (value) =>
            {
                canvasGroup.alpha = value;
            })
            .OnComplete(() =>
            {
                onClose?.Invoke();
                callback?.Invoke();
            });
    }

}
