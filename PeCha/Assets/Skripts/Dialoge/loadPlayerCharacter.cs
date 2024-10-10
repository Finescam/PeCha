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
            playerSprites[i].sprite = playChar.visualFeatures[i];
            playerSprites[i].color = playChar.colorOfFeature[i];
        }
    }

    private void Awake()
    {

        LoadFrontCharacter();

    }
}
