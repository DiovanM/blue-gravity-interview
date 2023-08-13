using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterCostumeManager
{

    public static Action<Costume> onEquipCostume;

    public static Action<CostumeType> onRemoveCostume;

    public static Dictionary<CostumeType, Costume> currentCostumes = new ();

    public static void EquipCostume(Costume costume)
    {
        RemoveCostume(costume.Type);

        currentCostumes.Add(costume.Type, costume);
        onEquipCostume?.Invoke(costume);
    }

    public static void RemoveCostume(CostumeType type)
    {
        if(currentCostumes.TryGetValue(type, out var costume))
        {
            currentCostumes.Remove(type);
            onRemoveCostume?.Invoke(type);
        }
    }

}
