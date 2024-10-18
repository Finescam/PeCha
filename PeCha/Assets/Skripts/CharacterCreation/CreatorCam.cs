using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatorCam : MonoBehaviour
{
    [SerializeField] GameObject allWindows;

    public void moveWindowsLeft()
    {
        allWindows.transform.position -= new Vector3(Screen.width, 0, 0);
    }

    public void moveWindowsRight()
    {
        allWindows.transform.position += new Vector3(Screen.width, 0, 0);
    }
}
