using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSettings : Singleton<GameSettings>
{

    [field: SerializeField] public GameData GameData { get; private set; }

}
