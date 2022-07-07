using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Goal : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log("hi");
        if (col.gameObject.tag == "Player")
        {
            //temp
            SceneManager.LoadScene(2);
        }
    }
}
