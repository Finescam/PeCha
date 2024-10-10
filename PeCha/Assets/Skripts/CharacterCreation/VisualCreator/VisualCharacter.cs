using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisualCharacter : MonoBehaviour
{
    // 0 = Body, 1 = Hair, 2 = Eyes, 3 = Brows, 4 = Nose, 5 = Mouth, 6 = Details, 7 = Accessoiry

    [SerializeField] public VisualLists visLists;
    [SerializeField] PlayerCharacter playChar;
    private Coloring coloring;
    [SerializeField] List<GameObject> featureButtons;
    [SerializeField] List<SpriteRenderer> spriteRenderers; 

    public int currentVisual = 0;

    private void Start()
    {
        coloring = this.GetComponent<Coloring>();
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
            sprite.sprite = visLists.allSpriteLists[i][0];
            sprite.color = Color.white;
            i++;
        }
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
        ChangeVisual(visLists.allSpriteLists[currentVisual], spriteRenderers[currentVisual], index);
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

        //add sprites and colors to playerchar lists, to use later
        for (int i = 0; i < spriteRenderers.Count; i++)
        {
            playChar.visualFeatures.Add(spriteRenderers[i].sprite);
            playChar.colorOfFeature.Add(spriteRenderers[i].color);
        }
    }
}
