using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisualCharacter : MonoBehaviour
{
    // 0 = Body, 1 = Hair, 2 = Eyes, 3 = Brows, 4 = Nose, 5 = Mouth, 6 = Details, 7 = Accessoiry

    [SerializeField] VisualLists visLists;
    [SerializeField] PlayerCharacter playChar;
    private Coloring coloring;
    [SerializeField] List<GameObject> featureButtons;
    [SerializeField] public List<SpriteRenderer> spriteRenderers; 

    public int currentVisual = 0;

    private void Start()
    {
        coloring = this.GetComponent<Coloring>();
        FillAllVisLists();
        //start on bodys because its the deafault currentValue and else it would shoot out of range exceptions.
        ChooseVisual(0);
        goToDefaultCharacter();
    }

    private void goToDefaultCharacter()
    {
        int i = 0;
        foreach (SpriteRenderer sprite in spriteRenderers)
        {
            //set each spriterenderers sprite to be the very first sprite out of all lists
            sprite.sprite = visLists.allVisualLists[i][0];
            sprite.color = Color.white;
            i++;
        }
    }

    private void FillAllVisLists()
    {
        //add every sprite list in visList here 
        visLists.allVisualLists.Add(visLists.bodySprites);
        visLists.allVisualLists.Add(visLists.hairSprites);
        visLists.allVisualLists.Add(visLists.eyeSprites);
        visLists.allVisualLists.Add(visLists.browSprites);
        visLists.allVisualLists.Add(visLists.noseSprites);
        visLists.allVisualLists.Add(visLists.mouthSprites);
        visLists.allVisualLists.Add(visLists.detailSprites);
        visLists.allVisualLists.Add(visLists.accessoirySprites);

        //add every colorlist in vislist here
        visLists.allColorLists.Add(visLists.bodyColor);
        visLists.allColorLists.Add(visLists.hairColor);
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
        if(visual < visLists.allColorLists.Count)
        coloring.ColorButtonsIn(visLists.allColorLists[visual]);

        //save current Visuals for other functions to use
        currentVisual = visual;
    }

    public void ChooseFeature(int index)
    {
        //use the currentVisual to pick what sprite we want to edit with which list from all VisuallLists, then set it to be the one with the handeled in index
        ChangeVisual(visLists.allVisualLists[currentVisual], spriteRenderers[currentVisual], index);
    }

    //Color in my sprite 
    public void ColorSprite(int index)
    {
        spriteRenderers[currentVisual].color = visLists.allColorLists[currentVisual][index];
    }

    public void AcceptVisuals()
    {
        //clear list for good measures
        playChar.visualFeatures.Clear();
        playChar.colorOfFeature.Clear();

        //add for each list the index of the chosen feature, so later i can read those for other sprites too
        for (int i = 0; i < visLists.allVisualLists.Count; i++)
        {
            //check if the sprite is contained in my list and save as index (if not it will return -1)
            int index = visLists.allVisualLists[i].IndexOf(spriteRenderers[i].sprite);
            //add index number if sprite were found, else add 0 for default option
            playChar.visualFeatures.Add(index >= 0 ? index : 0);
        }

        for (int i = 0; i < visLists.allColorLists.Count; i++)
        {
            int index = visLists.allColorLists[i].IndexOf(spriteRenderers[i].color);

            playChar.colorOfFeature.Add(index >= 0 ? index : 0);
        }
    }
}
