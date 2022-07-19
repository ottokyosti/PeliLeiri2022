using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ModeSwapSystem : MonoBehaviour
{
    public bool inManip = false;

    public enum AppliedManip { none, first, second, third, fourth };

    public AppliedManip CurrentManip = AppliedManip.none;

    [SerializeField]
    private GameObject ManipUI;

    [SerializeField]
    private GameObject bg1;

    [SerializeField]
    private GameObject bg2;

    [SerializeField]
    private GameObject bg3;

    [SerializeField]
    private GameObject bg4;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            SwapMode();
        }
        if (Input.GetKeyDown(KeyCode.Alpha1) && inManip)
        {
            ManipMode(1);
            bg1.SetActive(true);
            bg2.SetActive(false);
            bg3.SetActive(false);
            bg4.SetActive(false);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2) && inManip)
        {
            ManipMode(2);
            bg2.SetActive(true);
            bg1.SetActive(false);
            bg3.SetActive(false);
            bg4.SetActive(false);
        }
        if (Input.GetKeyDown(KeyCode.Alpha3) && inManip)
        {
            ManipMode(3);
            bg3.SetActive(true);
            bg2.SetActive(false);
            bg1.SetActive(false);
            bg4.SetActive(false);
        }
        if (Input.GetKeyDown(KeyCode.Alpha4) && inManip)
        {
            ManipMode(4);
            bg4.SetActive(true);
            bg2.SetActive(false);
            bg3.SetActive(false);
            bg1.SetActive(false);
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
    }
}
