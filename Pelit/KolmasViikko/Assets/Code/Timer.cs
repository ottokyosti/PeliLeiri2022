using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    private float time;
    public float _time
    {
        get { return time; }
    }
    private TMP_Text timeText;

    private void Start()
    {
        time = 0f;
        timeText = GetComponent<TMP_Text>();
        timeText.text = time.ToString("F2") + " s";
    }

    private void Update()
    {
        time += Time.deltaTime;
        timeText.text = time.ToString("F2") + " s";
    }
}
