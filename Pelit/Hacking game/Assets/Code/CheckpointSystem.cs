using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointSystem : MonoBehaviour
{
    public GameObject[] checkpoints;
    public int currentCP;
    private static CheckpointSystem checkpointSystemInstance;

    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
        if (checkpointSystemInstance == null)
        {
            checkpointSystemInstance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    public void ChangeCP(int checkpoint)
    {
        currentCP = checkpoint;
        Debug.Log(currentCP);
    }
}
