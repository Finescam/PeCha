using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class loadPlayerCharacter : MonoBehaviour
{
    [SerializeField] PlayerCharacter playChar;
    [SerializeField] List<SpriteRenderer> playerSprites;

    private void LoadFrontCharacter()
    {
        for (int i = 0; i < playChar.basicVisualFeatures.Count; i++)
        {
            playerSprites[i].sprite = playChar.basicVisualFeatures[i];
            if (i< playChar.colorOfFeature.Count)
            playerSprites[i].color = playChar.colorOfFeature[i];
        }
    }

    private void Awake()
    {

        LoadFrontCharacter();

    }
}
