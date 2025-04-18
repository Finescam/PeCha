using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VisualCharacter : MonoBehaviour
{
    // 0 = Body, 1 = Hair, 2 = Iris, 3 = Brows, 4 = Nose, 5 = Mouth, 6 = Details, 7 = Accessoiry, 8 = Beard, 9 = Eyes, 10 = HairBack, 11 = Clothes

    VisualLists visLists;
    ExtraSprites exSprites;
    [SerializeField] PlayerCharacter playChar;
    private Coloring coloring;
    [SerializeField] List<GameObject> featureButtons;
    [SerializeField] public List<SpriteRenderer> spriteRenderers;
    [SerializeField] SpriteRenderer clothesSprite;
    Clothes clothes;

    public int currentVisual = 0;

    private static bool goingBackToCreator;

    private void Start()
    {
        clothes = FindAnyObjectByType<Clothes>().GetComponent<Clothes>();
        exSprites = GetComponent<ExtraSprites>();
        visLists = VisualLists.Instance;
        coloring = this.GetComponent<Coloring>();
        //start on bodys because its the deafault currentValue and else it would shoot out of range exceptions.
        ChooseVisual(0);

        if(!goingBackToCreator)
        {
            goToDefaultCharacter();
            goingBackToCreator = true;
        }
        else
            ReloadCharacter();
    }

    public void goToDefaultCharacter()
    {
        int i = 0;
        foreach (SpriteRenderer sprite in spriteRenderers)
        {
            //set each spriterenderers sprite to be the very first sprite out of all lists
            sprite.sprite = visLists.allSpriteLists[i][0];
            if (i < visLists.allColorLists.Count) 
            sprite.color = visLists.allColorLists[i][0];
            i++;
        }
        exSprites.LoadAccordingEyes();
        exSprites.fixClothes();
    }

    private void ReloadCharacter()
    {
        //visual features
        int i = 0;
        foreach (SpriteRenderer sprite in spriteRenderers)
        {
            if (playChar.basicVisualFeatures.Count > 0)
            {
                sprite.sprite = playChar.basicVisualFeatures[i];
                if (i < playChar.colorOfFeature.Count)
                    sprite.color = playChar.colorOfFeature[i];
                i++;
            }
        }
        clothesSprite.color = playChar.colorOfFeature[playChar.colorOfFeature.Count-1];
        exSprites.fixClothes();
        exSprites.LoadAccordingEyes();
    }

    private void ChangeVisual(List<Sprite> spriteList, SpriteRenderer sprite, int index)
    {
        //change the current Sprite to match the chosen feature Sprite from visList
        sprite.sprite = spriteList[index];
    }

    public void ChooseVisual(int visual)
    {
        //set all buttons invisible/unactive
        foreach (GameObject button in featureButtons)
        {
            button.SetActive(false);
        }
        //except the chosen feature button
        featureButtons[visual].SetActive(true);

        //display available color if available
        if (visual < visLists.allColorLists.Count)
            coloring.ColorButtonsIn(visLists.allColorLists[visual]);
        else
            coloring.TurnButtonsOff();

        //save current Visuals for other functions to use
        currentVisual = visual;
    }

    public void ChooseFeature(int index)
    {
        //use the currentVisual to pick what sprite we want to edit with which list from all VisuallLists, then set it to be the one with the handeled in index
        ChangeVisual(visLists.allSpriteLists[currentVisual], spriteRenderers[currentVisual], index);
    }

    //Color in my sprite 
    public void ColorSprite(int index)
    {
        if (currentVisual < visLists.allColorLists.Count)
            spriteRenderers[currentVisual].color = visLists.allColorLists[currentVisual][index];
        else
            clothesSprite.color = clothes.clothColor[index];
    }

    public void AcceptVisuals()
    {
        //clear list for good measures
        playChar.basicVisualFeatures.Clear();
        playChar.chosenVisualFeatures.Clear();
        playChar.colorOfFeature.Clear();

        //add sprites and colors to playerchar lists, to use later
        for (int i = 0; i < spriteRenderers.Count; i++)
        {
            int x = visLists.allSpriteLists[i].IndexOf(spriteRenderers[i].sprite);
            playChar.chosenVisualFeatures.Add(x);
            playChar.basicVisualFeatures.Add(spriteRenderers[i].sprite);
            playChar.colorOfFeature.Add(spriteRenderers[i].color);
        }
        //eyes has the same index as iris, so i add eye index extra
        playChar.basicVisualFeatures.Add(exSprites.eyesSpriteRen.sprite);
        playChar.chosenVisualFeatures.Add(visLists.irisSprites.IndexOf(spriteRenderers[2].sprite));
        playChar.colorOfFeature.Add(Color.white);
        playChar.basicVisualFeatures.Add(exSprites.backHairRen.sprite);
        playChar.chosenVisualFeatures.Add(visLists.hairSprites.IndexOf(spriteRenderers[1].sprite));
        playChar.colorOfFeature.Add(exSprites.backHairRen.color);
        playChar.basicVisualFeatures.Add(exSprites.clothesSpriteRen.sprite);
        playChar.chosenVisualFeatures.Add(exSprites.clothIndex);
        playChar.colorOfFeature.Add(clothesSprite.color);
    }
}
