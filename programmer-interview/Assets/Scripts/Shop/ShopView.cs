using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShopView : Popup
{

    [SerializeField] private TextMeshProUGUI titleText;
    [SerializeField] private TextMeshProUGUI totalPurchaseText;
    [SerializeField] private TextMeshProUGUI currencyBalanceText;
    [SerializeField] private List<ShopItemView> shopItemViews;
    [SerializeField] private Button purchaseButton;
    [SerializeField] private Button closeButton;

    private Action<List<Item>> onFinishPurchase;
    private Action onClose;
    private List<Item> selectedItems;
    private int purchaseValue;
    private int playerBalance;

    private void Awake()
    {
        closeButton.onClick.AddListener(() =>
        {
            CanvasManager.instance.ClosePopup(this);
            onClose?.Invoke();
        });
        purchaseButton.onClick.AddListener(FinishPurchase);
    }

    public void Setup(List<Item> items, string title, Action<List<Item>> onFinishPurchase, Action onClose)
    {

        selectedItems = new List<Item>();
        purchaseValue = 0;

        this.onFinishPurchase = onFinishPurchase;
        this.onClose = onClose;

        playerBalance = CurrencyManager.Currency;
        titleText.text = title;

        for (int i = 0; i < shopItemViews.Count; i++)
        {
            var itemView = shopItemViews[i];

            itemView.Clear();
            itemView.SetEnable(false);
        }

        for (int i = 0; i < items.Count; i++)
        {
            var item = items[i];

            var itemView = shopItemViews[i];

            itemView.Setup(item);
            itemView.onClick += OnClickItem;
        }

        UpdatePurchase();
    }

    private void OnClickItem(ShopItemView itemView)
    {

        if(itemView.selected)
        {
            itemView.Deselect();
            OnDeselectItem(itemView);
        }
        else
        {
            itemView.Select();
            OnSelectItem(itemView);
        }

    }

    private void OnSelectItem(ShopItemView itemView)
    {
        selectedItems.Add(itemView.referencedItem);
        purchaseValue += itemView.referencedItem.defaultPrice;

        UpdatePurchase();
    }

    private void OnDeselectItem(ShopItemView itemView)
    {
        selectedItems.Remove(itemView.referencedItem);
        purchaseValue -= itemView.referencedItem.defaultPrice;

        UpdatePurchase();
    }

    private void UpdatePurchase()
    {
        totalPurchaseText.text = purchaseValue.ToString();

        var newBalance = playerBalance - purchaseValue;

        currencyBalanceText.text = newBalance.ToString();

        if (newBalance <= 0 || selectedItems.Count == 0)
        {
            purchaseButton.interactable = false;
        }
        else
        {
            purchaseButton.interactable = true;
        }
    }

    private void FinishPurchase()
    {
        onFinishPurchase?.Invoke(selectedItems);

        CanvasManager.instance.ClosePopup(this);
    }

}
