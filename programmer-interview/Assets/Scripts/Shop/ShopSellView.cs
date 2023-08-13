using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShopSellView : Popup
{

    [SerializeField] private TextMeshProUGUI titleText;
    [SerializeField] private TextMeshProUGUI totalSellText;
    [SerializeField] private TextMeshProUGUI currencyBalanceText;
    [SerializeField] private List<ShopItemView> shopItemViews;
    [SerializeField] private Button sellButton;
    [SerializeField] private Button closeButton;

    private Action<List<Item>> onFinishSell;
    private Action onClose;
    private List<Item> selectedItems;
    private int sellValue;
    private int playerBalance;

    private void Awake()
    {
        closeButton.onClick.AddListener(() =>
        {
            CanvasManager.instance.ClosePopup(this);
            onClose?.Invoke();
        });
        sellButton.onClick.AddListener(FinishSell);
    }

    public void Setup(List<Item> items, string title, Action<List<Item>> onFinishSell, Action onClose)
    {

        selectedItems = new List<Item>();
        sellValue = 0;

        this.onFinishSell = onFinishSell;
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

            itemView.Setup(item, true);
            itemView.onClick += OnClickItem;
        }

        UpdateSell();
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
        sellValue += itemView.referencedItem.defaultSellPrice;

        UpdateSell();
    }

    private void OnDeselectItem(ShopItemView itemView)
    {
        selectedItems.Remove(itemView.referencedItem);
        sellValue -= itemView.referencedItem.defaultSellPrice;

        UpdateSell();
    }

    private void UpdateSell()
    {
        totalSellText.text = sellValue.ToString();

        var newBalance = playerBalance + sellValue;

        currencyBalanceText.text = newBalance.ToString();

        if (newBalance <= 0 || selectedItems.Count == 0)
        {
            sellButton.interactable = false;
        }
        else
        {
            sellButton.interactable = true;
        }
    }

    private void FinishSell()
    {
        onFinishSell?.Invoke(selectedItems);

        CanvasManager.instance.ClosePopup(this);
    }

}
