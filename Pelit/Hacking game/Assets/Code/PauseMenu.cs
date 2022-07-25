using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    private bool spamInhibitor = true;

    [SerializeField] private GameObject canvas;

    private void Start()
    {
        //DontDestroyOnLoad(this.gameObject);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (canvas.activeSelf)
            {
                Resume();
            }
            else if (!(canvas.activeSelf) && spamInhibitor)
            {
                Time.timeScale = 0;
                canvas.SetActive(true);
            }
        }
    }

    IEnumerator WaitTime()
    {
        yield return new WaitForSecondsRealtime(0.5f);
        spamInhibitor = true;
    }

    public void Resume()
    {
        Time.timeScale = 1;
        canvas.SetActive(false);
        spamInhibitor = false;
        StartCoroutine(WaitTime());
    }

    public void Mainmenu()
    {
        Time.timeScale = 1;
        canvas.SetActive(false);
        spamInhibitor = false;
        StartCoroutine(WaitTime());
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
