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
        if (!reached && col.gameObject.tag == "Player")
        {
            reached = true;
            system.ChangeCP(checkpointIndex);
            GetComponent<Animator>().SetBool("Triggered", true);
        }
    }

}
