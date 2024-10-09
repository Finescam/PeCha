using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class loadPlayerCharacter : MonoBehaviour
{
    [SerializeField] VisualLists visList;
    [SerializeField] PlayerCharacter playChar;
    [SerializeField] List<SpriteRenderer> playerSprites;

    private void LoadFrontCharacter()
    {
        for (int i = 0; i < playerSprites.Count; i++)
        {
            playerSprites[i].sprite = visList.allVisualLists[i][playChar.visualFeatures[i]];
        }
    }

    private void Awake()
    {

        LoadFrontCharacter();

    }
}
