using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShopItemView : MonoBehaviour
{

    public Action<ShopItemView> onClick;

    public PointerHandler pointerHandler;
    public TextMeshProUGUI priceText;
    public Image background;
    public Image icon;
    public Item referencedItem;

    public bool selected;

    public void Setup(Item item)
    {
        icon.sprite = item.icon;
        priceText.text = item.defaultPrice.ToString();

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
        priceText.text = "0";
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
