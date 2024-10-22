using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Coloring : MonoBehaviour
{
    [SerializeField] List<Button> colorButtons;

    private void Start()
    {
        ColorButtonsIn(VisualLists.Instance.bodyColor);
    }

    public void ColorButtonsIn(List<Color32> currentList)
    {
        TurnButtonsOff();
        for (int i = 0; i < currentList.Count; i++)
        {
            colorButtons[i].image.color = currentList[i];
            colorButtons[i].gameObject.SetActive(true);
        }
    }

    public void ColorClothes()
    {
        ColorButtonsIn(Clothes.Instance.clothColor);
    }

    public void TurnButtonsOff()
    {
        foreach (Button colorButton in colorButtons)
        {
            colorButton.gameObject.SetActive(false);
        }
    }
}
