using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ink.Runtime;

public class InkVars : MonoBehaviour
{
    [SerializeField] PlayerCharacter playChar;

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
        SetInkVariable("Pron", playChar.characterPronoun);
        FillInktList("Traits", playChar.characterTraits);
        FillInktList("Visuals", playChar.visualTraits);
    }
}
