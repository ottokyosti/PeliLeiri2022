using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupManager : MonoBehaviour
{
    public bool pointsx2 = false;

    [SerializeField]
    private float timer = 10;

    [SerializeField]
    private GameObject powerUpDisplay;
    private float origTimer;

    void Start()
    {
        origTimer = timer;
    }

    void Update()
    {
        if(pointsx2)
        {
            timer -= Time.deltaTime;
            if(timer <= 0)
            {
                pointsx2 = false;
                timer = origTimer;
                powerUpDisplay.SetActive(false);
            }
        }
    }
}
