using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TraitData : MonoBehaviour
{
    [Header("Visuals")]
    [SerializeField] Toggle toggle;
    [SerializeField] Slider slider;
    [SerializeField] TMP_Text traitAText;
    [SerializeField] TMP_Text traitBText;
    [SerializeField] Image traitPanel;
    Color enabledcolor = Color.white;
    Color disabledColor = Color.grey;

    [Header("Values")]
    public bool usingTrait;
    public float traitValue;
    public string traitA;
    public string traitB;

    public string chosenTrait;

    private void Start()
    {
        traitAText.text = traitA;
        traitBText.text = traitB;
    }

    public void ToggleSwitch()
    {
        slider.value = 0;
        UpdateTraitValue();
    }

    private void UpdateUsing()
    {
        if (traitValue == 0)
        {
            usingTrait = false;
            traitPanel.color = disabledColor;
        }        
        else
        {
            usingTrait = true;
            traitPanel.color = enabledcolor;
        }
           
    }

    public void UpdateTraitValue()
    {
        traitValue = slider.value;

        UpdateUsing();
    }

    public void UpdateChosenTrait()
    {
        if (traitValue > 0)
            chosenTrait = traitB;
        else if (traitValue < 0)
            chosenTrait = traitA;
    }
}
