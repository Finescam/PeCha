using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine;

public class EndCharacterCreation : MonoBehaviour
{
    [SerializeField] TMP_Text nameandAge;
    [SerializeField] TMP_Text endTraits;
    [SerializeField] PlayerCharacter playChar;

    public void LoadDialogeScene()
    {
        SceneManager.LoadScene("Adventure");
    }

    public void AddSumup()
    {
        nameandAge.text = $"{playChar.characterName} {playChar.characterSurname} ({playChar.characterAge})";
        endTraits.text = string.Join("\n", playChar.prioritizedTraits);
    }
}
