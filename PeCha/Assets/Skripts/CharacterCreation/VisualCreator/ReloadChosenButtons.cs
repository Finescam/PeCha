using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReloadChosenButtons : MonoBehaviour
{
    //useless
    [SerializeField] List<ButtonHighlight> buttonRepresentive;
    private static bool cursedCheck;

    private void Awake()
    {
        if (cursedCheck)
            ReloadChosenButton();
    }

    void ReloadChosenButton()
    {
        cursedCheck = true;
        foreach (ButtonHighlight buttonRep in buttonRepresentive)
        {
            foreach (Button button in buttonRep.groupedButtons)
            {
                ButtonHighlight bh = button.GetComponent<ButtonHighlight>();
                if (!bh.wasChosen)
                    return;
                else
                {
                    bh.ReloadChosen(button, button.colors.disabledColor);
                }
            }
        }
    }
}
