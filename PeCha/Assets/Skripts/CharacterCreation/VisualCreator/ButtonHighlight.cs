using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ButtonHighlight : MonoBehaviour
{
    [SerializeField] public List<Button> groupedButtons;
    private Button thisButton;
    public bool wasChosen;

    private void Awake()
    {
        thisButton= this.GetComponent<Button>();
    }

    private void Start()
    {
        SetBasic();
    }

    private void SetBasic()
    {
        ResetButtons(groupedButtons[0], groupedButtons[0].colors.disabledColor);
    }

    //Doesnt work
    public void ReloadChosen(Button rebutton, Color recolor)
    {
        ResetButtons(rebutton,recolor);
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
            button.GetComponent<ButtonHighlight>().wasChosen = false;
        }
        ColorBlock tcb = myButton.colors;
        tcb.normalColor = thisButton.colors.selectedColor;
        myButton.colors = tcb;
        wasChosen = true;
    }
}
