using UnityEngine;

public abstract class Item : ScriptableObject
{

    public new string name;
    public Sprite icon;
    public int defaultPrice;
    public int defaultSellPrice;

}
