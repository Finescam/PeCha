using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Emotionsprites : MonoBehaviour
{
    public static Emotionsprites Instance;
    [SerializeField] PlayerCharacter playChar;

    //all possible fear animation Sprites
    [SerializeField] List<Sprite> fearBody;
    [SerializeField] List<Sprite> fearHair;
    [SerializeField] List<Sprite> fearHairBack;
    [SerializeField] List<Sprite> fearEyes;
    [SerializeField] List<Sprite> fearIris;
    [SerializeField] List<Sprite> fearbrow;
    [SerializeField] List<Sprite> fearnose;
    [SerializeField] List<Sprite> fearmouth;
    [SerializeField] List<Sprite> feardetail;
    [SerializeField] List<Sprite> fearaccessory;
    [SerializeField] List<Sprite> fearbeard;
    private List<List<Sprite>> allfearLists;
    public List<Sprite> fearCharacter;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;

        allfearLists = new List<List<Sprite>>
        {
            fearBody, fearHair, fearIris, fearbrow, fearnose, fearmouth,feardetail,fearaccessory, fearbeard, fearEyes, fearHairBack
        };

        LoadEmotions();
    }

    public void LoadEmotions()
    {
        for (int i = 0; i < allfearLists.Count; i++)
        {
                fearCharacter.Add(allfearLists[i][playChar.chosenVisualFeatures[i]]);
            //for all possible future emotions just make a sprite sheet animation instead
        }
    }
}
