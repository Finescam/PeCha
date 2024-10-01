using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChosenCharakter : MonoBehaviour
{
    [SerializeField] List<TraitData> allTraits;
   [SerializeField]
    PlayerCharacter playChar;

    public void createCharacter()
    {
        playChar.chosenTraits.Clear();
        playChar.chosenTraitValue.Clear();

        foreach (TraitData trait in allTraits)
        {
            trait.UpdateChosenTrait();

            if (trait.usingTrait)
            {
                playChar.chosenTraits.Add(trait.chosenTrait);
                playChar.chosenTraitValue.Add(trait.traitValue);
            }
        }
    }

    //public void UpdateChosenTrait()
    //{
    //    if (traitValue > 0)
    //        chosenTrait = traitB;
    //    else if (traitValue < 0)
    //        chosenTrait = traitA;
    //}
}
