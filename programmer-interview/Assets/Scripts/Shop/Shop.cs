using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{

    [SerializeField] private ProximityDetector proximityDetector;
    [SerializeField] private List<Item> initialItems;

    private void Start()
    {
        proximityDetector.onEnter += (gameObject) =>
        {
            CanvasManager.instance.OpenShop(initialItems, "Shop", ProcessPurchase);
        };
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
    }



}
