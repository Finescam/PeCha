using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class TagBehavior : MonoBehaviour
{
    [SerializeField] ExtraSprites exSprites;
    [SerializeField] Animator layoutAnimator;
    [SerializeField] loadPlayerCharacter loadPC;
    [SerializeField] GameObject NPCSprite;
    [SerializeField] GameObject PlayerSprite;

    public void HandleTags(List<string> currentTags)
    {
        foreach (string tag in currentTags)
        {
            string[] splitTag = tag.Split(":");
            string tagKey = splitTag[0];
            string tagValue = splitTag[1];

            switch (tagKey)
            {
                case "System":
                    SystemTag(tagValue);
                    break;
                case "Layout":
                    LayoutTag(tagValue);
                    break;
                case "PlayerAnim":
                    LoadAnimation(tagValue);
                    break;
                default:
                    Debug.LogWarning("something went wrong with the TagKeys. Tagkey: " + tagKey);
                    break;

            }
        }
    }

    private void SystemTag(string value)
    {
        switch (value)
        {
            case "LoadNextStory":
                Debug.Log("loading next scene.");
                break;
            case "CharacterCreator":
                SceneManager.LoadScene(0);
                break;
            case "Quit":
                Application.Quit();
                break;
            default:
                Debug.LogWarning("Something went wrong with the Value. System Value: " + value);
                break;
        }
    }

    private void LayoutTag(string value)
    {
        layoutAnimator.Play(value);
        switch (value)
        {
            case "NPC":
                NPCSprite.SetActive(true);
                break;
            case "Player":
                NPCSprite.SetActive(false);
                break;
            case "Narrator":
                break;
            default:
                Debug.LogWarning("Something went wrong with the Value. System Value: " + value);
                break;
        }
    }

    private void SetLayoutNPC(bool isNPC)
    {
        NPCSprite.SetActive(isNPC);
        PlayerSprite.SetActive(!isNPC);

        //if (isNPC)
        //    layoutAnimator.Play("Player");
        //else
        //    layoutAnimator.Play("NPC");
    }   

    private void LoadAnimation(string value)
    {
        switch(value)
        {
            case "Fear":
                loadPC.LoadFearCharacter();
                exSprites.loadClothes(exSprites.playChar.chosenVisualFeatures[exSprites.playChar.chosenVisualFeatures.Count - 1]);
                break;
            default:
                loadPC.LoadFrontCharacter();
                exSprites.basicClothes();
                break;
        }

    }
}
