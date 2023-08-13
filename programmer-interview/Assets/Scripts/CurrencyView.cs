using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CurrencyView : MonoBehaviour
{

    [SerializeField] private TextMeshProUGUI currencyValueText;

    private void Start()
    {
        currencyValueText.text = CurrencyManager.Currency.ToString();

        CurrencyManager.onAddCurrency += UpdateCurrency;
        CurrencyManager.onRemoveCurrency += UpdateCurrency;
    }

    private void OnDestroy()
    {
        CurrencyManager.onAddCurrency -= UpdateCurrency;
        CurrencyManager.onRemoveCurrency -= UpdateCurrency;
    }

    private void UpdateCurrency(int value)
    {
        currencyValueText.text = value.ToString();
    }

}
