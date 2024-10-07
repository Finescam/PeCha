using System.Collections;
using System;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ChosenCharakter : MonoBehaviour
{
    [SerializeField] TMP_InputField age;
    [SerializeField] TMP_InputField firstName;
    [SerializeField] TMP_InputField surName;
    [SerializeField] List<TraitData> allTraits;
    [SerializeField] public PlayerCharacter playChar;
    [SerializeField] WarningPopUp warningPopUp;

    public List<string> chosenTraits;
    public List<float> chosenTraitValues;

    public void createCharacter()
    {
        GetChosenTraits();
        //check if everything is filled out, else popup note
        StartCoroutine(warningPopUp.panelFadeout());        
    }

    public float turnValuePositive(float i)
    {
        if (i < 0)
            i = i * -1;

        return i;
    }

    public void GetAge()
    {
        if (age.text != "")
            playChar.characterAge = int.Parse(age.text);
        else
            playChar.characterAge = 0;

        //let note appear if character <18 or >90 (not possible)
    }

    public void GetName()
    {
        playChar.characterName = firstName.text;
    }

    public void GetSurName()
    {
        playChar.characterSurname = surName.text;
    }

    private void GetChosenTraits()
    {
        chosenTraits.Clear();
        chosenTraitValues.Clear();

        foreach (TraitData trait in allTraits)
        {
            trait.UpdateChosenTrait();

            if (trait.usingTrait)
            {
                chosenTraits.Add(trait.chosenTrait);
                chosenTraitValues.Add(turnValuePositive(trait.traitValue));
            }
        }

        //sort trait priority and add them to the final list
        var combinedList = chosenTraits.Zip(chosenTraitValues, (traits, values) => new { Trait = traits, Value = values });
        var sortedList = combinedList.OrderByDescending(item => item.Value).ToList();

        playChar.prioritizedTraits = sortedList.Select(item => item.Trait).ToList();
    }

}
