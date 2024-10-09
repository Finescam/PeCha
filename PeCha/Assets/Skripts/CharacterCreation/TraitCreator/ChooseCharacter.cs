using System.Collections;
using System;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ChooseCharacter : MonoBehaviour
{
    [SerializeField] TMP_InputField age;
    [SerializeField] TMP_InputField firstName;
    [SerializeField] TMP_InputField surName;
    [SerializeField] List<TraitData> allTraits;
    [SerializeField] public PlayerCharacter playChar;
    WarningPopUp warningPopUp;
    CreatorCam cam;

    public List<string> chosenTraits;
    public List<float> chosenTraitValues;

    private void Start()
    {
        warningPopUp = FindObjectOfType<WarningPopUp>().GetComponent<WarningPopUp>();
        cam = FindObjectOfType<CreatorCam>().GetComponent<CreatorCam>();
    }

    public void CreateCharacter()
    {
        GetChosenTraits();
        //check if everything is filled out, else popup note
        if(warningPopUp.checkWarningState())
        {
            cam.moveWindowsLeft();
        }
    }

    private float turnValuePositive(float i)
    {
        if (i < 0)
            i = i * -1;

        return i;
    }

    public void GetAge()
    {
        if (age.text != "" && int.Parse(age.text) >= 18 && int.Parse(age.text) <= 90)
        {
            playChar.characterAge = int.Parse(age.text);
            warningPopUp.ageGiven = true;
        }
        else
        {
            playChar.characterAge = 0;
            warningPopUp.ageGiven = false;
        }
    }

    public void GetName()
    {
        if (firstName.text != "")
        {
            playChar.characterName = firstName.text;
            warningPopUp.nameGiven = true;
        }
        else
        {
            playChar.characterName = "";
            warningPopUp.nameGiven = false;
        }
    }

    public void GetSurName()
    {
        if (surName.text != "")
        {
            playChar.characterSurname = surName.text;
            warningPopUp.surnameGiven = true;
        }
        else
        {
            playChar.characterSurname = "";
            warningPopUp.surnameGiven = false;
        }
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

        //check if at least one trait was chosen
        if (playChar.prioritizedTraits.Count >= 1)
            warningPopUp.traitChosen = true;
        else
            warningPopUp.traitChosen = false;
    }

}
