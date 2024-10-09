using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class WarningPopUp : MonoBehaviour
{
    [SerializeField] TMP_Text warningText;
    [SerializeField] CanvasGroup warningPanel;
    public float fadingTime;

    public bool ageGiven = false;
    public bool nameGiven = false;
    public bool surnameGiven = false;
    public bool traitChosen = false;

    private IEnumerator panelFadeout()
    {
        float counter = 0;
        warningPanel.alpha = 1;

        while (counter < fadingTime)
        {
            counter += Time.deltaTime;
            warningPanel.alpha = Mathf.Lerp(1, 0, counter/fadingTime);
            yield return null;
        }
    }

    public bool checkWarningState()
    {
        //Check if every field is given a value, else show warning popup
        if (!traitChosen)
        {
            warningText.text = "Please choose at least one trait";
        }
        else if (!ageGiven)
        {
            warningText.text = "Please enter age between 18 and 90";
        }
        else if(!nameGiven)
        {
            warningText.text = "Please enter name";
        }
        else if (!surnameGiven)
        {
            warningText.text = "Please enter surname";
        }
        else
        {
            return true;
        }
        StartCoroutine(panelFadeout());
        return false;
    }
}
