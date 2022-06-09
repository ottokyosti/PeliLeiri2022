using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    private int score;

    [SerializeField]
    private GameObject[] spawners;

    private enum SpeedState
    { normal, fast, faster, fastest };

    private SpeedState state;

    public void AddScore(int amount)
    {
        score += amount;
        if(score >= 50 && state == SpeedState.normal)
        {
            state = SpeedState.fast;
            foreach(GameObject spawner in spawners)
            {
                spawner.GetComponent<Spawner>().SpeedUp(1);
            }
        }
        if(score >= 100 && state == SpeedState.fast)
        {
            state = SpeedState.faster;
            foreach(GameObject spawner in spawners)
            {
                spawner.GetComponent<Spawner>().SpeedUp(1);
            }
        }
        if(score >= 150 && state == SpeedState.faster)
        {
            state = SpeedState.fastest;
            foreach(GameObject spawner in spawners)
            {
                spawner.GetComponent<Spawner>().SpeedUp(1);
            }
        }
    }

    void Start()
    {
        state = SpeedState.normal;
    }

    private void Update()
    {
        GetComponent<TMP_Text>().text = score.ToString();
    }
}
