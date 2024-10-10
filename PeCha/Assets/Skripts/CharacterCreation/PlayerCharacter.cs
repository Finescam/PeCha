using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class PlayerCharacter : ScriptableObject
{
    public int characterAge;
    public string characterName;
    public string characterSurname;
    public List<string> prioritizedTraits;

    public List<Sprite> visualFeatures;
    public List<Color32> colorOfFeature;

    public List<Sprite> sideVisualFeatures; //may be needed later
}
