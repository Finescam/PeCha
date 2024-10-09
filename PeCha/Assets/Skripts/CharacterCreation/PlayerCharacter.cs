using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacter : ScriptableObject
{
    public int characterAge;
    public string characterName;
    public string characterSurname;
    public List<string> prioritizedTraits;

    public int body;
    public int hair;
    public int cloth;
    public int face; //schaumamal 
}
