using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimeStealer : MonoBehaviour
{
    private TMP_Text timeText;
    private float time;
    [SerializeField] private GameObject timer;

    private void Awake()
    {
        timeText = GetComponent<TMP_Text>();
        time = timer.GetComponent<Timer>()._time;
        timeText.text = time.ToString("F2") + " s";
    }
}
