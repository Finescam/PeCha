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
    public List<Sprite> accessoirySprites;
    public List<List<Sprite>> allVisualLists = new List<List<Sprite>>();

    public List<Color32> bodyColor;
    public List<Color32> hairColor;
    public List<List<Color32>> allColorLists = new List<List<Color32>>();

    private void Awake()
    {
        FillAllVisLists();
    }

    private void FillAllVisLists()
    {
        //add every sprite list in visList here 
        allVisualLists.Add(bodySprites);
        allVisualLists.Add(hairSprites);
        allVisualLists.Add(eyeSprites);
        allVisualLists.Add(browSprites);
        allVisualLists.Add(noseSprites);
        allVisualLists.Add(mouthSprites);
        allVisualLists.Add(detailSprites);
        allVisualLists.Add(accessoirySprites);

        //add every colorlist in vislist here
        allColorLists.Add(bodyColor);
        allColorLists.Add(hairColor);
    }
}
