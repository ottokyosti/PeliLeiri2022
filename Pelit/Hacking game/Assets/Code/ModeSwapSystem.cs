using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModeSwapSystem : MonoBehaviour
{
    private bool inManip = false;
    public void SwapMode()
    {
        if(!inManip)
        {
            Time.timeScale = 0;
        }
        else if(inManip)
        {
            Time.timeScale = 1;
        }
        inManip = !inManip;
        Debug.Log(inManip);
    }
}
