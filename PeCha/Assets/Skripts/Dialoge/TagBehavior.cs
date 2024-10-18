using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TagBehavior : MonoBehaviour
{
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
            default:
                Debug.LogWarning("Something went wrong with the Value. System Value: " + value);
                break;
        }
    }

    private void LayoutTag(string value)
    {
        switch (value)
        {
            case "NPC":
                Debug.Log("NPC is speaking.");
                break;
            case "Player":
                Debug.Log("Player is speaking");
                break;
            default:
                Debug.LogWarning("Something went wrong with the Value. System Value: " + value);
                break;
        }
    }
}
