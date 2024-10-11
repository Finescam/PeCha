using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisualLists : MonoBehaviour
{
    public static VisualLists Instance;

    public List<Sprite> bodySprites;
    public List<Sprite> hairSprites;
    public List<Sprite> eyeSprites;
    public List<Sprite> irisSprites;
    public List<Sprite> browSprites;
    public List<Sprite> noseSprites;
    public List<Sprite> mouthSprites;
    public List<Sprite> detailSprites;
    public List<Sprite> accessorySprites;
    public List<List<Sprite>> allSpriteLists;

    public List<Color32> bodyColor;
    public List<Color32> hairColor;
    public List<List<Color32>> allColorLists;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;

        FillAllLists();
    }

    private void FillAllLists()
    {
        allSpriteLists = new List<List<Sprite>>
        {
            bodySprites, hairSprites, irisSprites, browSprites, noseSprites, mouthSprites, detailSprites, accessorySprites
        };

        allColorLists = new List<List<Color32>>
        {
            bodyColor, hairColor
        };
    }
}
