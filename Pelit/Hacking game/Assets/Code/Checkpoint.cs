using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    [SerializeField]
    private int checkpointIndex;
    private bool reached = false;
    private CheckpointSystem system;

    // Start is called before the first frame update
    void Start()
    {
        system = FindObjectOfType<CheckpointSystem>();
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log("touch");
        if (!reached && col.gameObject.tag == "Player")
        {
            Debug.Log("player touch");
            reached = true;
            system.ChangeCP(checkpointIndex);
        }
    }
}
