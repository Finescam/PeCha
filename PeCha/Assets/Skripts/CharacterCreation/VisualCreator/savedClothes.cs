using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class savedClothes: MonoBehaviour
{
    public static savedClothes Instance;

    public Sprite[] bodytype0Clothes;
    public Sprite[] bodytype1Clothes;
    public Sprite[] bodytype2Clothes;
    public Sprite[] bodytype3Clothes;
    public Sprite[] bodytype4Clothes;
    public Sprite[] bodytype5Clothes;
    public List<Sprite[]> allBodytypeClothes;

    private void Awake()
    {
        if(Instance == null)
        Instance = this;

        FillAllListList();
    }

    void FillAllListList()
    {
        allBodytypeClothes = new List<Sprite[]>
       {
            bodytype0Clothes, bodytype1Clothes, bodytype2Clothes, bodytype3Clothes, bodytype4Clothes, bodytype5Clothes
       };
    }
}
