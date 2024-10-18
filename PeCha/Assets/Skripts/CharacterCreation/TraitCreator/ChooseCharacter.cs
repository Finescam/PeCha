using System.Collections;
using System;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class ChooseCharacter : MonoBehaviour
{
    [SerializeField] TMP_InputField age;
    [SerializeField] TMP_InputField firstName;
    [SerializeField] TMP_InputField surName;
    [SerializeField] List<TraitData> allTraits;
    [SerializeField] TMP_Dropdown pronoun;
    [SerializeField] public PlayerCharacter playChar;
    WarningPopUp warningPopUp;

    public List<string> chosenTraits;
    public List<float> chosenTraitValues;

    private static bool goingBackToCreator = false;

    private void Start()
    {
        warningPopUp = FindObjectOfType<WarningPopUp>().GetComponent<WarningPopUp>();
        if (goingBackToCreator)
            ReloadCharacter();
        else
            goingBackToCreator = true;

    }

    public void ReloadCharacter()
    {
        age.text = playChar.characterAge.ToString();
        firstName.text = playChar.characterName;
        surName.text = playChar.characterSurname;
        pronoun.value = playChar.chosenGender;

        if (playChar.traitvalues.Count != 0)
        {
            int i = 0;
            foreach (TraitData trait in allTraits)
            {
                trait.slider.value = playChar.traitvalues[i];
                i++;
            }
        }

        GetAge();
        GetName();
        GetSurName();
    }

    public void CreateCharacter()
    {
        GetChosenTraits();
        //check if everything is filled out before finishing, else popup note
        if(warningPopUp.checkWarningState())
        {
           SceneManager.LoadScene("Adventure");
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

    public void GetPronoun()
    {
        int pickedEntryIndex = pronoun.value;
        playChar.chosenGender = pickedEntryIndex;
        playChar.characterPronoun = pronoun.options[pickedEntryIndex].text;
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
        playChar.traitvalues.Clear();

        foreach (TraitData trait in allTraits)
        {
            playChar.traitvalues.Add(trait.slider.value);
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

        playChar.characterTraits = sortedList.Select(item => item.Trait).ToList();

        //check if at least one trait was chosen
        if (playChar.characterTraits.Count >= 1)
            warningPopUp.traitChosen = true;
        else
            warningPopUp.traitChosen = false;
    }

}
