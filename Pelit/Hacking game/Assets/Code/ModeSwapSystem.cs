using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModeSwapSystem : MonoBehaviour
{
    private bool inManip = false;

    [SerializeField]
    private GameObject ManipUI;

    public void SwapMode()
    {
        if(!inManip)
        {
            Time.timeScale = 0;
            ManipUI.SetActive(true);
        }
        else if(inManip)
        {
            Time.timeScale = 1;
            ManipUI.SetActive(false);
        }
        inManip = !inManip;
    }
}
