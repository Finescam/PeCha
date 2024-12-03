using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class BackgroundTraits : MonoBehaviour
{
    [SerializeField] PlayerCharacter playChar;
    [SerializeField] Color32 basic;
    [SerializeField] Color32 extrovert;
    [SerializeField] Color32 witch;
    [SerializeField] Color32 paranoid;
    [SerializeField] Color32 depressed;
    [SerializeField] Color32 stern;
    [SerializeField] Color32 romantic;
    List<string> extroverted = new List<string> {"Confident", "Humorous", "Charming", "Inquisitive", "Sceptical"};
    List<string> witchy = new List<string> { "Confident", "Serious", "Rude", "Superstitious"};
    List<string> paranoido = new List<string> { "Anxious", "Superstitious", "Inquisitive"};
    List<string> depresso = new List<string> { "Anxious", "Sceptical", "Serious", "Indifferent"};
    List<string> sterny = new List<string> { "Confident", "Sceptical", "Serious", "Indifferent"};
    List<string> romantical = new List<string> { "Confident", "Humorous", "Charming", "Superstitious"};

    [SerializeField] List<SpriteRenderer> BGSprites;

    private void Awake()
    {
        foreach (SpriteRenderer sprite in BGSprites)
        {
            sprite.gameObject.SetActive(false);
            sprite.color = CurrentColor();

            //I dont want anxious specifically to color in with the rest, because it is supposed to glow.
            if(sprite.gameObject.name == "Anxious")
            {
                sprite.color = basic;
            }

            if(playChar.characterTraits.Contains(sprite.gameObject.name))
            {
                sprite.gameObject.SetActive(true);
            }
        }
        BGSprites[0].gameObject.SetActive(true);
    }

    private Color32 CurrentColor()
    {
        if (extroverted.All(obj => playChar.characterTraits.Contains(obj)))
            return extrovert;
        else if (witchy.All(obj => playChar.characterTraits.Contains(obj)))
            return witch;
        else if (paranoido.All(obj => playChar.characterTraits.Contains(obj)))
            return paranoid;
        else if (depresso.All(obj => playChar.characterTraits.Contains(obj)))
            return depressed;
        else if (sterny.All(obj => playChar.characterTraits.Contains(obj)))
            return stern;
        else if (romantical.All(obj => playChar.characterTraits.Contains(obj)))
            return romantic;
        else
            return basic;
    }
}
