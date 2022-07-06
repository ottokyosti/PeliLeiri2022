using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModeSwapSystem : MonoBehaviour
{
    public bool inManip = false;

    public enum AppliedManip { none, first, second, third, fourth };

    public AppliedManip CurrentManip = AppliedManip.none;

    [SerializeField]
    private GameObject ManipUI;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            SwapMode();
        }
        if (Input.GetKeyDown(KeyCode.Alpha1) && inManip)
        {
            ManipMode(1);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2) && inManip)
        {
            ManipMode(2);
        }
        if (Input.GetKeyDown(KeyCode.Alpha3) && inManip)
        {
            ManipMode(3);
        }
        if (Input.GetKeyDown(KeyCode.Alpha4) && inManip)
        {
            ManipMode(4);
        }
    }

    private void SwapMode()
    {
        if (!inManip)
        {
            Time.timeScale = 0;
            ManipUI.SetActive(true);
        }
        else if (inManip)
        {
            Time.timeScale = 1;
            ManipUI.SetActive(false);
        }
        inManip = !inManip;
        Debug.Log(inManip);
    }

    private void ManipMode(int input)
    {
        switch (input)
        {
            case 1:
                CurrentManip = AppliedManip.first;
                break;
            case 2:
                CurrentManip = AppliedManip.second;
                break;
            case 3:
                CurrentManip = AppliedManip.third;
                break;
            case 4:
                CurrentManip = AppliedManip.fourth;
                break;
        }
        Debug.Log(CurrentManip);
    }
}
