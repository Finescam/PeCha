using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChosenVisuals : MonoBehaviour
{
    [SerializeField] List<EffectVisual> effectVisuals;
    [SerializeField] PlayerCharacter playChar;

    //fill visualTraits List in playChar with the Strings, that return true
    public void FillChosenVisualList()
    {
        playChar.visualTraits.Clear();
        int i = 0;
        foreach(int visual in playChar.chosenVisualFeatures)
        {
            foreach (EffectVisual effect in effectVisuals)
            {
                if (effect.visList == i)
                {
                    if (visual >= effect.startIndex && visual <= effect.endIndex)
                    {
                        playChar.visualTraits.Add(effect.visName);
                    }
                }
            }
            i++;
        }
    }
}
