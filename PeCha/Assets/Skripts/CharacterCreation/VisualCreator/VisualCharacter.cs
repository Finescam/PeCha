using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisualCharacter : MonoBehaviour
{
    // 0 = Body, 1 = Hair, 2 = Eyes, 3 = Brows, 4 = Nose, 5 = Mouth, 6 = Clothes

    [SerializeField] VisualLists visLists;
    [SerializeField] PlayerCharacter playChar;
    public List<List<Sprite>> allVisLists = new List<List<Sprite>>();
    [SerializeField] List<GameObject> featureButtons;
    [SerializeField] List<SpriteRenderer> spriteRenderers; 

    int currentVisual = 0;

    private void Start()
    {
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
            sprite.sprite = allVisLists[i][0];
            i++;
        }
    }

    private void FillAllVisLists()
    {
        //add every "front" list in visList here 
        allVisLists.Add(visLists.bodySpritesFront);
        allVisLists.Add(visLists.hairSpritesFront);
        allVisLists.Add(visLists.eyeSpritesFront);
        allVisLists.Add(visLists.browSpritesFront);
        allVisLists.Add(visLists.noseSpritesFront);
        allVisLists.Add(visLists.mouthSpritesFront);
        allVisLists.Add(visLists.clothesSpritesFront);
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

        //save current Visuals for other functions to use
        currentVisual = visual;
    }

    public void ChooseFeature(int index)
    {
        //use the currentVisual to pick what sprite we want to edit with which list from all VisuallLists, then set it to be the one with the handeled in index
        ChangeVisual(allVisLists[currentVisual], spriteRenderers[currentVisual], index);
    }

    public void AcceptVisuals()
    {
        //clear list for good measures
        playChar.visualFeatures.Clear();
        //add for each list the index of the chosen feature, so later i can read those for other sprites too
        for (int i = 0; i < allVisLists.Count; i++)
        {
            playChar.visualFeatures.Add(allVisLists[i].IndexOf(spriteRenderers[i].sprite));
        }
    }
}
