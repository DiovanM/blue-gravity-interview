using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasManager : Singleton<CanvasManager>
{
    [SerializeField] private GameObject screenlocker;

    [SerializeField] private ShopView shopView;

    private void Start()
    {
        screenlocker.SetActive(false);
        shopView.gameObject.SetActive(false);
    }

    public void OpenShop(List<Item> items, string title)
    {
        screenlocker.SetActive(true);

        shopView.Setup(items, title);
        shopView.Open();
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
