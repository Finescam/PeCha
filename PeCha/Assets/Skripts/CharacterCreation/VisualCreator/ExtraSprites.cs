using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExtraSprites : MonoBehaviour
{
    VisualLists visLists;
    VisualCharacter visChar;
    [SerializeField] SpriteRenderer clothesSpriteRen;
    [SerializeField] SpriteRenderer eyesSpriteRen;

    private void Start()
    {
        visLists = VisualLists.Instance;
        visChar = this.GetComponent<VisualCharacter>();
    }

    public void loadClothes(int index)
    {
        clothesSpriteRen.sprite = savedClothes.Instance.allBodytypeClothes[CurrentBodyType()][index];
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
