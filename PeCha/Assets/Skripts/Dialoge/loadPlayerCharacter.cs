using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class loadPlayerCharacter : MonoBehaviour
{
    [SerializeField] PlayerCharacter playChar;
    [SerializeField] List<SpriteRenderer> playerSprites;

    private void LoadFrontCharacter()
    {
        for (int i = 0; i < playChar.visualFeatures.Count; i++)
        {
            playerSprites[i].sprite = playChar.visualFeatures[i];
            if (i< playChar.colorOfFeature.Count)
            playerSprites[i].color = playChar.colorOfFeature[i];
        }
    }

    private void Awake()
    {

        LoadFrontCharacter();

    }
}
