using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{

    [SerializeField] private ProximityDetector proximityDetector;
    [SerializeField] private List<Item> initialItems;
    [SerializeField] private GameObject canvas;
    [SerializeField] private Button buyButton;
    [SerializeField] private Button sellButton;

    private void Start()
    {
        proximityDetector.onEnter += ShowCanvas;
        proximityDetector.onExit += HideCanvas;

        buyButton.onClick.AddListener(OpenShop);
        sellButton.onClick.AddListener(OpenSellShop);

        HideCanvas(null);
    }

    private void ShowCanvas(GameObject gameObject)
    {
        canvas.SetActive(true);
    }

    private void HideCanvas(GameObject gameObject)
    {
        canvas.SetActive(false);
    }

    private void OpenShop()
    {
        CanvasManager.instance.OpenShop(initialItems, "Shop", ProcessPurchase, () => ShowCanvas(null));
        HideCanvas(null);
    }

    private void OpenSellShop()
    {
        //CanvasManager.instance.OpenShop(initialItems, "Sell", ProcessPurchase);
    }

    private void ProcessPurchase(List<Item> purchasedItems)
    {
        var totalValue = 0;

        for (int i = 0; i < purchasedItems.Count; i++)
        {
            var item = purchasedItems[i];

            totalValue += item.defaultPrice;

            initialItems.Remove(item);

            InventoryManager.AddItem(item);
        }

        CurrencyManager.RemoveCurrency(totalValue);

        ShowCanvas(null);
    }



}
