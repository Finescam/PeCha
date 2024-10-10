using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class VisualLists : ScriptableObject
{
    public List<Sprite> bodySprites;
    public List<Sprite> hairSprites;
    public List<Sprite> eyeSprites;
    public List<Sprite> browSprites;
    public List<Sprite> noseSprites;
    public List<Sprite> mouthSprites;
    public List<Sprite> detailSprites;
    public List<Sprite> accessoirySprites;
    public List<List<Sprite>> allVisualLists = new List<List<Sprite>>();

    public List<Color32> bodyColor;
    public List<Color32> hairColor;
    public List<List<Color32>> allColorLists = new List<List<Color32>>();
}
