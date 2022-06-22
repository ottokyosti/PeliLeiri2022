using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{
    [SerializeField] private GameObject endOfLevelMenu;
    [SerializeField] private GameObject victorySound;
    [SerializeField] private GameObject timer;

    private void Start()
    {
        Time.timeScale = 1;
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "Player")
        {
            Time.timeScale = 0;
            Destroy(timer);
            Instantiate(victorySound, transform.position, transform.rotation);
            endOfLevelMenu.SetActive(true);
        }
    }
}
