using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TopMenu : MonoBehaviour
{

    [SerializeField] private Button costumeViewButton;

    private void Awake()
    {
        costumeViewButton.onClick.AddListener(OpenCostumeView);
    }

    private void OpenCostumeView()
    {
        CanvasManager.instance.OpenCostumeView(InventoryManager.PlayerItems);
    }

}
