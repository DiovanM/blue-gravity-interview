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
            CanvasManager.instance.OpenShop(initialItems, "Shop");
        };
    }

}
