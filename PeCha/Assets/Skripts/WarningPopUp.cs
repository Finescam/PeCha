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

    public IEnumerator panelFadeout()
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
}
