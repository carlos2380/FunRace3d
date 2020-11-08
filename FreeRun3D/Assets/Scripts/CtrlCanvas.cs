using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CtrlCanvas : MonoBehaviour
{
    public GameObject winMenu;
    public GameObject startMenu;


    public void win()
    {
        winMenu.SetActive(true);
    }

    public void play()
    {
        winMenu.SetActive(false);
        startMenu.SetActive(false);
    }
}
