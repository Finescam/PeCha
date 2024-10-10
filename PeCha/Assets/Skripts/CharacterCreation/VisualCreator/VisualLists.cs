using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisualLists : MonoBehaviour
{
    public List<Sprite> bodySprites;
    public List<Sprite> hairSprites;
    public List<Sprite> eyeSprites;
    public List<Sprite> browSprites;
    public List<Sprite> noseSprites;
    public List<Sprite> mouthSprites;
    public List<Sprite> detailSprites;
    public List<Sprite> accessorySprites;
    public List<List<Sprite>> allSpriteLists = new List<List<Sprite>>();

    public List<Color32> bodyColor;
    public List<Color32> hairColor;
    public List<List<Color32>> allColorLists = new List<List<Color32>>();

    private void Awake()
    {
        FillAllLists();
    }

    private void FillAllLists()
    {
        var spriteLists = new List<Sprite>[]
        {
            bodySprites, hairSprites, eyeSprites, browSprites, noseSprites, mouthSprites, detailSprites, accessorySprites
        };

        var colorLists = new List<Color32>[]
        {
            bodyColor, hairColor
        };

        allSpriteLists.AddRange(spriteLists);
        allColorLists.AddRange(colorLists);
    }
}
