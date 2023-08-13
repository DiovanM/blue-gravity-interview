using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class ProximityDetector : MonoBehaviour
{

    public Action<GameObject> onEnter;
    public Action<GameObject> onExit;

    private new Collider2D collider;

    private void Awake()
    {
        collider = GetComponent<Collider2D>();
        collider.isTrigger = true;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        onEnter?.Invoke(other.gameObject);
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        onExit?.Invoke(other.gameObject);
    }

}
