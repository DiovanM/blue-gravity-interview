using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager
{

    public static Action<Item> onItemAdded;
    public static Action<Item> onItemRemoved;

    public static List<Item> PlayerItems { get; private set; } = new List<Item>();

    public static void AddItem(Item item)
    {
        PlayerItems.Add(item);
        onItemAdded?.Invoke(item);
    }

    public static void RemoveItem(Item item)
    {
        if(PlayerItems.Contains(item))
        {
            PlayerItems.Remove(item);
            onItemRemoved?.Invoke(item);
        }
        else
        {
            Debug.LogError("Tried to remove unexisting item from inventory");
        }
    }

}
