using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadNextScene : MonoBehaviour
{
    public void LoadNext()
    {
        int index = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(index + 1);
    }

    public void LevelLoad(int levelIndex)
    {
        SceneManager.LoadScene(levelIndex);
    }
    
    public void ExitGame()
    {
        Application.Quit();
    }
}
