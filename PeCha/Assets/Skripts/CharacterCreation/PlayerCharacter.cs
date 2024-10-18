using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class PlayerCharacter : ScriptableObject
{
    public int characterAge;
    public string characterPronoun = "They/Them/Their";
    public int chosenGender;
    public string characterName;
    public string characterSurname;
    public List<float> traitvalues;
    public List<string> characterTraits;
    public List<string> visualTraits;

    public List<int> chosenVisualFeatures;
    public List<Sprite> basicVisualFeatures;
    public List<Color32> colorOfFeature;
}
