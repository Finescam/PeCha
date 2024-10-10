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

    public void loadClothes(int index)
    {
        //clothesSpriteRen.sprite = 
    }

    int CurrentBodyType()
    {
       return visChar.visLists.bodySprites.IndexOf(clothesSpriteRen.sprite);
    }
}
