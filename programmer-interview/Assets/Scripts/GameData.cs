using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GameData", menuName = "Scriptable Objects/Game Data")]
public class GameData : ScriptableObject
{

    public float characterSpeed = 2.5f;
    public int startingCurrency = 300;

}
