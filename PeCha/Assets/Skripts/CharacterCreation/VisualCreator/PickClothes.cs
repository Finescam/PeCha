using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickClothes : MonoBehaviour
{
    VisualCharacter visChar;
    SpriteRenderer clothesSpriteRen;

    private void Start()
    {
        visChar = this.GetComponent<VisualCharacter>();
    }

    int CurrentBodyType()
    {
       return visChar.visLists.bodySprites.IndexOf(clothesSpriteRen.sprite);
    }
}
