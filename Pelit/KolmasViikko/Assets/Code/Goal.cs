using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{
    [SerializeField] private GameObject endOfLevelMenu;

    private void OnTriggerEnter2D(Collider2D col)
    {
        endOfLevelMenu.SetActive(true);
    }
}
