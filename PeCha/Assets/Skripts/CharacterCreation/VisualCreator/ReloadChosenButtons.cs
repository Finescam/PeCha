using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReloadChosenButtons : MonoBehaviour
{
    //useless
    [SerializeField] List<ButtonHighlight> buttonRepresentive;
    [SerializeField] ButtonHighlight mainButton;
    [SerializeField] PlayerCharacter playChar;
    private static bool cursedCheck;

    private void Start()
    {
        if(!cursedCheck)
        {
            cursedCheck = true;
            foreach(ButtonHighlight bh in buttonRepresentive)
            {
                bh.SetBasic();
            }
            mainButton.SetBasic();
            return;
        }
        else
        ReloadChosenButton();
    }

    int index;
    void ReloadChosenButton()
    {
        mainButton.SetBasic();
        foreach(ButtonHighlight bh in buttonRepresentive)
        {
            bh.ReloadChosen(bh.groupedButtons[ChosenVisual(index)], bh.groupedButtons[ChosenVisual(index)].colors.disabledColor);
            index++;
        }
    }

    private int ChosenVisual(int i)
    {
        return playChar.chosenVisualFeatures[i] >= 0 ? playChar.chosenVisualFeatures[i] : 0;
    }
}
