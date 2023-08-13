using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasManager : Singleton<CanvasManager>
{
    [SerializeField] private GameObject screenlocker;

    [SerializeField] private ShopView shopView;
    [SerializeField] private ShopSellView shopSellView;
    [SerializeField] private CostumeView costumeView;

    private void Start()
    {
        screenlocker.SetActive(false);
        shopView.gameObject.SetActive(false);
        shopSellView.gameObject.SetActive(false);
        costumeView.gameObject.SetActive(false);
    }

    public void OpenShop(List<Item> items, string title, Action<List<Item>> onFinishPurchase, Action onClose)
    {
        screenlocker.SetActive(true);

        shopView.Setup(items, title, onFinishPurchase, onClose);
        shopView.Open();
    }

    public void OpenSellShop(List<Item> items, string title, Action<List<Item>> onFinishSell, Action onClose)
    {
        screenlocker.SetActive(true);

        shopSellView.Setup(items, title, onFinishSell, onClose);
        shopSellView.Open();
    }

    public void OpenCostumeView(List<Item> items)
    {
        screenlocker.SetActive(true);

        costumeView.Setup(items);
        costumeView.Open();
    }

    public void ClosePopup(Popup popup)
    {
        popup.Close(() =>
        {
            popup.gameObject.SetActive(false);
            screenlocker.SetActive(false);
        });
    }

}
