using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Goal : MonoBehaviour
{
    [SerializeField]
    private int sceneIndex;

    [SerializeField]
    private bool resetCheckpoints = true;

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            if (resetCheckpoints)
            {
                Destroy(FindObjectOfType<CheckpointSystem>().gameObject);
            }
            SceneManager.LoadScene(sceneIndex);
        }
    }
}
