using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CostumeView : Popup
{

    [SerializeField] private List<CostumeViewItem> costumeViewItems;
    [SerializeField] private Button closeButton;

    private Dictionary<CostumeType, CostumeViewItem> selectedCostumes = new();

    private void Awake()
    {
        closeButton.onClick.AddListener(() =>
        {
            CanvasManager.instance.ClosePopup(this);
            onClose?.Invoke();
        });
    }

    public void Setup(List<Item> items)
    {

        selectedCostumes = new();

        var currentPlayerCostumes = CharacterCostumeManager.currentCostumes;

        var costumeItems = new List<Costume>();

        for (int i = 0; i < items.Count; i++)
        {
            var item = items[i];

            if(item is Costume costume)
            {
                costumeItems.Add(costume);
            }
        }

        for (int i = 0; i < costumeViewItems.Count; i++)
        {

            var view = costumeViewItems[i];

            if(i < costumeItems.Count)
            {
                var costumeItem = costumeItems[i];

                view.Setup(costumeItem);
                view.onClick += OnClickCostume;

                if (currentPlayerCostumes.TryGetValue(costumeItem.Type, out var costume) && costume == costumeItem)
                {
                    selectedCostumes.Add(costumeItem.Type, view);
                    view.Select();
                }
            }
            else
            {
                view.SetEnable(false);
            }
        }
    }

    private void OnClickCostume(CostumeViewItem costume)
    {
        if(selectedCostumes.TryGetValue(costume.referencedItem.Type, out var selectedCostume))
        {
            selectedCostume.Deselect();

            if(selectedCostume == costume)
            {
                selectedCostumes.Remove(costume.referencedItem.Type);
                CharacterCostumeManager.RemoveCostume(costume.referencedItem.Type);
                return;
            }

            selectedCostumes[costume.referencedItem.Type] = costume;
        }
        else
        {
            selectedCostumes.Add(costume.referencedItem.Type, costume);
        }

        costume.Select();
        CharacterCostumeManager.EquipCostume(costume.referencedItem);
    }

}
