using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterCostume : MonoBehaviour
{

    [Header("Idle Renderers")]

    [SerializeField] private SpriteRenderer bottomIdleOutfit;
    [SerializeField] private SpriteRenderer bottomIdleHat;

    [SerializeField] private SpriteRenderer topIdleOutfit;
    [SerializeField] private SpriteRenderer topIdleHat;

    [SerializeField] private SpriteRenderer rightIdleOutfit;
    [SerializeField] private SpriteRenderer rightIdleHat;

    [SerializeField] private SpriteRenderer leftIdleOutfit;
    [SerializeField] private SpriteRenderer leftIdleHat;

    [Header("Walking Renderers")]

    [SerializeField] private List<SpriteRenderer> bottomWalkingOutfit;
    [SerializeField] private List<SpriteRenderer> bottomWalkingHat;

    [SerializeField] private List<SpriteRenderer> topWalkingOutfit;
    [SerializeField] private List<SpriteRenderer> topWalkingHat;

    [SerializeField] private List<SpriteRenderer> rightWalkingOutfit;
    [SerializeField] private List<SpriteRenderer> rightWalkingHat;

    [SerializeField] private List<SpriteRenderer> leftWalkingOutfit;
    [SerializeField] private List<SpriteRenderer> leftWalkingHat;

    private void Awake()
    {
        CharacterCostumeManager.onEquipCostume += ApplyCostume;
        CharacterCostumeManager.onRemoveCostume += RemoveCostume;
    }

    private void OnDestroy()
    {
        CharacterCostumeManager.onEquipCostume -= ApplyCostume;
        CharacterCostumeManager.onRemoveCostume -= RemoveCostume;
    }

    public void ApplyCostume(Costume costume)
    {
        switch(costume.Type)
        {
            case CostumeType.Hat:
                {
                    bottomIdleHat.sprite = costume.bottomIdle;
                    topIdleHat.sprite = costume.topIdle;
                    leftIdleHat.sprite = costume.leftIdle;
                    rightIdleHat.sprite = costume.rightIdle;

                    for (int i = 0; i < 6; i++)
                    {
                        bottomWalkingHat[i].sprite = costume.bottomWalking[i];
                        topWalkingHat[i].sprite = costume.topWalking[i];
                        leftWalkingHat[i].sprite = costume.leftWalking[i];
                        rightWalkingHat[i].sprite = costume.rightWalking[i];
                    }

                    break;
                }
            case CostumeType.Outfit:
                {

                    break;
                }
        }
    }

    public void RemoveCostume(CostumeType type)
    {
        switch (type)
        {
            case CostumeType.Hat:
                {
                    bottomIdleHat.sprite = null;
                    topIdleHat.sprite = null;
                    leftIdleHat.sprite = null;
                    rightIdleHat.sprite = null;

                    for (int i = 0; i < 6; i++)
                    {
                        bottomWalkingHat[i].sprite = null;
                        topWalkingHat[i].sprite = null;
                        leftWalkingHat[i].sprite = null;
                        rightWalkingHat[i].sprite = null;
                    }

                    break;
                }
            case CostumeType.Outfit:
                {

                    break;
                }
        }
    }

}
