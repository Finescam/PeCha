using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Coloring : MonoBehaviour
{
    [SerializeField] VisualLists visList;
    [SerializeField] List<Button> colorButtons;

    private void Start()
    {
        ColorButtonsIn(visList.bodyColor);
    }

    public void ColorButtonsIn(List<Color32> currentList)
    {
        foreach (Button colorButton in colorButtons)
        {
            colorButton.gameObject.SetActive(false);
        }

        for (int i = 0; i < currentList.Count; i++)
        {
            colorButtons[i].image.color = currentList[i];
            colorButtons[i].gameObject.SetActive(true);
        }
    }
}
