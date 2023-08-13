using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CostumeViewItem : MonoBehaviour
{

    public Action<CostumeViewItem> onClick;

    public PointerHandler pointerHandler;
    public Image background;
    public Image icon;
    public Costume referencedItem;

    public bool selected;

    public void Setup(Costume item)
    {
        icon.sprite = item.icon;

        pointerHandler.onPointerUp += (e) => onClick?.Invoke(this);

        referencedItem = item;

        SetEnable(true);
    }

    public void Select()
    {
        background.enabled = true;
        selected = true;
    }

    public void Clear()
    {
        icon.sprite = null;
        pointerHandler.onPointerUp = null;
        referencedItem = null;
    }

    public void Deselect()
    {
        background.enabled = false;
        selected = false;
    }

    public void SetEnable(bool enable)
    {
        gameObject.SetActive(enable);
    }

}
