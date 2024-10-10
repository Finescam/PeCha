using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class loadPlayerCharacter : MonoBehaviour
{
    [SerializeField] VisualLists frontVisList;
    [SerializeField] PlayerCharacter playChar;
    [SerializeField] List<SpriteRenderer> playerSprites;

    private void LoadFrontCharacter()
    {
        for (int i = 0; i < playerSprites.Count; i++)
        {
            playerSprites[i].sprite = frontVisList.allVisualLists[i][playChar.visualFeatures[i]];
        }

        for (int i = 0; i < frontVisList.allColorLists.Count; i++)
        {
            playerSprites[i].color = frontVisList.allColorLists[i][playChar.colorOfFeature[i]];
        }
    }

    private void Awake()
    {

        LoadFrontCharacter();

    }
}
