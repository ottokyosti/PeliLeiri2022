using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateManager : MonoBehaviour
{
    [SerializeField]
    private GameObject gameOverText;

    [SerializeField]
    private GameObject winText;
    public void GameOver(bool win)
    {
        if(win)
        {
            winText.SetActive(true);
        }
        else
        {
            Time.timeScale = 0;
            gameOverText.SetActive(true);
        }
    }
}
