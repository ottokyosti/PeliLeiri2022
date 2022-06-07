using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    private int score;

    public void AddScore(int amount)
    {
        score += amount;
    }

    private void Update()
    {
        GetComponent<TMP_Text>().text = score.ToString();
    }
}
