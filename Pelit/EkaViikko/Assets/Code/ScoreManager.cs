using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    private float score;

    public void AddScore(float amount)
    {
        score += amount;
        Debug.Log("score: " + score);
    }
}
