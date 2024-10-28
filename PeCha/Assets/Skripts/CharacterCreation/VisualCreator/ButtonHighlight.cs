using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ButtonHighlight : MonoBehaviour
{
    [SerializeField] public List<Button> groupedButtons;
    private Button thisButton;

    private void Awake()
    {
        thisButton= this.GetComponent<Button>();
    }

    public void SetBasic()
    {
        ResetButtons(groupedButtons[0], groupedButtons[0].colors.disabledColor);
    }

    public void ReloadChosen(Button rebutton, Color reColor)
    {
        ResetButtons(rebutton,reColor);
    }

    public void HighlightButton()
    {
        ResetButtons(thisButton, Color.grey);
    }

    public void HighlightMainButtons()
    {
        ResetButtons(thisButton, Color.white);       
    }

    private void ResetButtons(Button myButton, Color myColor)
    {
        foreach (Button button in groupedButtons)
        {
            ColorBlock cb = button.colors;
            cb.normalColor = myColor;
            button.colors = cb;
        }
        ColorBlock tcb = myButton.colors;
        tcb.normalColor = thisButton.colors.selectedColor;
        myButton.colors = tcb;
    }
}
