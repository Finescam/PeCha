using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExtraSprites : MonoBehaviour
{
    VisualLists visLists;
    VisualCharacter visChar;
    [SerializeField] public PlayerCharacter playChar;
    public SpriteRenderer clothesSpriteRen;
    public SpriteRenderer eyesSpriteRen;
    private static int currentClothes;
    public int clothIndex;
    Clothes clothes;

    private void Awake()
    {
        clothes = FindAnyObjectByType<Clothes>().GetComponent<Clothes>();
        visLists = VisualLists.Instance;
        visChar = this.GetComponent<VisualCharacter>();
    }

    public void loadClothes(int index)
    {
        currentClothes = index;
        clothIndex = index;
        clothesSpriteRen.sprite = clothes.allBodytypeClothes[CurrentBodyType()][currentClothes];
    }

    public void basicClothes()
    {
        clothesSpriteRen.sprite = playChar.basicVisualFeatures[playChar.basicVisualFeatures.Count - 1];
    }

    public void fixClothes()
    {
        loadClothes(currentClothes);
    }

    public void LoadAccordingEyes()
    {
        eyesSpriteRen.sprite = visLists.eyeSprites[CurrentEyeType()];
    }

    public int CurrentBodyType()
    {
        if (visLists != null)
        {
            playChar.currentBodytype = visLists.bodySprites.IndexOf(visChar.spriteRenderers[0].sprite);
        }
        return playChar.currentBodytype;

    }

    private int CurrentEyeType()
    {
        return visLists.irisSprites.IndexOf(visChar.spriteRenderers[2].sprite);
    }
}
