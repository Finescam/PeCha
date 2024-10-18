using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ink.Runtime;

public class InkVars : MonoBehaviour
{
    [SerializeField] PlayerCharacter playChar;

    private void SetPrononce()
    {
        string[] pronounce = playChar.characterPronoun.Split("/");

        for(int i = 0; i < pronounce.Length; i++)
        {
            SetInkVariable("Pron" + i, pronounce[i]);
        }
    }

    private void SetInkVariable(string inkVar, string charVar)
    {
        DialogeSystem.instance.currentInkStory.variablesState[inkVar] = charVar;
    }

    private void FillInktList(string inkListName, List<string> values)
    {
        var currentValues = new Ink.Runtime.InkList(inkListName, DialogeSystem.instance.currentInkStory);
        foreach (string trait in values)
        {
            currentValues.AddItem(trait);
        }
        DialogeSystem.instance.currentInkStory.variablesState[inkListName] = currentValues;
    }

    public void LoadCharacter()
    {
        SetInkVariable("Name", playChar.characterName);
        SetInkVariable("Surname", playChar.characterSurname);
        SetInkVariable("Age", playChar.characterAge.ToString());
        SetPrononce();
        FillInktList("Traits", playChar.characterTraits);
        FillInktList("Visuals", playChar.visualTraits);
    }
}
