using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateManager : MonoBehaviour
{
    [SerializeField]
    private GameObject gameOverText;
    public void GameOver()
    {
        Time.timeScale = 0;
        gameOverText.SetActive(true);
    }
}
