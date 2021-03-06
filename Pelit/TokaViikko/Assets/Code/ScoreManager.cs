using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    private int score;

    private PowerupManager powerupManager;

    [SerializeField]
    private TMP_Text endText;

    [SerializeField]
    private float health = 3;

    [SerializeField]
    private GameObject healthSlider;

    [SerializeField]
    private GameObject gameOver;

    [SerializeField]
    private GameObject[] spawners;

    private enum SpeedState
    { normal, fast, faster, fastest };

    private SpeedState state;

    public void AddScore(int amount)
    {
        if(amount < 0)
        {
            healthSlider.GetComponent<Slider>().value--;
            health--;
            if(health <= 0)
            {
                Cursor.visible = true;
                gameOver.SetActive(true);
                Time.timeScale = 0;
            }
        }
        if(powerupManager.pointsx2)
        {
            score += (amount * 2);
            endText.text = score.ToString();
        }
        else
        {
            score += amount;
            endText.text = score.ToString();
        }
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
        powerupManager = FindObjectOfType<PowerupManager>();
    }

    private void Update()
    {
        if (score <= 0)
        {
            GetComponent<TMP_Text>().text = "0";
            score = 0;
            endText.text = score.ToString();
        }
        else
        {
            GetComponent<TMP_Text>().text = score.ToString();
        }  
    }
}
