using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryViewItem : MonoBehaviour
{

    public Image icon;
    public Item referencedItem;

    private void Awake()
    {
        icon.enabled = false;
    }

    public void Setup(Item item)
    {
        icon.sprite = item.icon;
        icon.enabled = true;

        referencedItem = item;
    }

    public void Clear()
    {
        icon.sprite = null;
        icon.enabled = false;
        referencedItem = null;
    }

}
