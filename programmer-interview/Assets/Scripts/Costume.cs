using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Costume", menuName = "Scriptable Objects/Costume")]
public class Costume : Item
{
    [field: SerializeField] public CostumeType Type { get; private set; }

    [Header("Idle Sprites")]

    public Sprite bottomIdle;
    public Sprite topIdle;
    public Sprite rightIdle;
    public Sprite leftIdle;

    [Header("Walking Sprites")]

    public List<Sprite> bottomWalking;
    public List<Sprite> topWalking;
    public List<Sprite> rightWalking;
    public List<Sprite> leftWalking;
}

public enum CostumeType
{
    Outfit,
    Hat
}