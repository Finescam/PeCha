using System.Collections;
using System;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;

public class ChosenCharakter : MonoBehaviour
{
    [SerializeField] List<TraitData> allTraits;
   [SerializeField]
    PlayerCharacter playChar;

    public List<string> chosenTraits;
    public List<float> chosenTraitValues;

    public void createCharacter()
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

        sortTraitPriority();
    }

    public void sortTraitPriority()
    {
        var combinedList = chosenTraits.Zip(chosenTraitValues, (traits, values) => new { Trait = traits, Value = values });
        var sortedList = combinedList.OrderByDescending(item => item.Value).ToList();

        playChar.prioritizedTraits = sortedList.Select(item => item.Trait).ToList();
    }

    public float turnValuePositive(float i)
    {
        if (i < 0)
            i = i * -1;

        return i;
    }
}
