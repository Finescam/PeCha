using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExtraSprites : MonoBehaviour
{
    VisualLists visLists;
    VisualCharacter visChar;
    public SpriteRenderer clothesSpriteRen;
    public SpriteRenderer eyesSpriteRen;
    private static int currentClothes;

    private void Awake()
    {
        visLists = VisualLists.Instance;
        visChar = this.GetComponent<VisualCharacter>();
    }

    public void loadClothes(int index)
    {
        currentClothes = index;
        clothesSpriteRen.sprite = Clothes.Instance.allBodytypeClothes[CurrentBodyType()][currentClothes];
    }

    public void fixClothes()
    {
        loadClothes(currentClothes);
    }

    public void LoadAccordingEyes()
    {
        eyesSpriteRen.sprite = visLists.eyeSprites[CurrentEyeType()];
    }

    int CurrentBodyType()
    {
       return visLists.bodySprites.IndexOf(visChar.spriteRenderers[0].sprite);
    }

    private int CurrentEyeType()
    {
        return visLists.irisSprites.IndexOf(visChar.spriteRenderers[2].sprite);
    }
}
