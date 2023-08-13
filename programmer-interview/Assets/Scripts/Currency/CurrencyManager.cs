using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrencyManager : Singleton<CurrencyManager>
{

    public static Action<int> onAddCurrency;
    public static Action<int> onRemoveCurrency;

    public static int Currency { get; private set; }

    private void Start()
    {
        Currency = GameSettings.instance.GameData.startingCurrency;
    }

    public static void AddCurrency(int value)
    {
        Currency += value;

        onAddCurrency?.Invoke(Currency);
    }

    public static bool RemoveCurrency(int value)
    {
        if (Currency >= value)
        {
            Currency -= value;
            onRemoveCurrency?.Invoke(Currency);
            return true;
        }
        else
        {
            Debug.LogError("Tried to remove currency with value higher than available");
            return false;
        }
    }

}
