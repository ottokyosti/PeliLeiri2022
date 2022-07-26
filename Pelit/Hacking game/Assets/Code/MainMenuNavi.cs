using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuNavi : MonoBehaviour
{
    public void QuitApplication()
    {
        Application.Quit();
    }

    public void LoadNextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void CodeTextChange(string textToWrite)
    {
        TextWriter.codeText.WriteText(textToWrite);
    }
}
