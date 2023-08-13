using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryView : MonoBehaviour
{

    [SerializeField] private List<InventoryViewItem> itemViews;

    private Queue<InventoryViewItem> availableSlots;
    private Dictionary<Item, InventoryViewItem> itemSlotsDictionary = new();

    private void Awake()
    {
        InventoryManager.onItemAdded += OnItemAdded;
        InventoryManager.onItemRemoved += OnItemRemoved;

        availableSlots = new (itemViews);
    }

    private void OnDestroy()
    {
        InventoryManager.onItemAdded -= OnItemAdded;
        InventoryManager.onItemRemoved -= OnItemRemoved;
    }

    private void OnItemAdded(Item item)
    {
        var slot = availableSlots.Dequeue();

        slot.Setup(item);

        itemSlotsDictionary.Add(item, slot);
    }

    private void OnItemRemoved(Item item)
    {
        var slot = itemSlotsDictionary[item];

        slot.transform.SetAsLastSibling();
        slot.Clear();

        availableSlots.Enqueue(slot);

        itemSlotsDictionary.Remove(item);
    }

}
