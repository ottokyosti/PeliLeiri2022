using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    private float score;

    public void AddScore(float amount)
    {
        score += amount;
        GetComponent<TMP_Text>().text = score.ToString();
        Debug.Log("score: " + score);
    }
}
