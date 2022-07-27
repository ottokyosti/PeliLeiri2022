using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpen : MonoBehaviour
{
    public bool open = false;

    private bool complete = false;
    
    [SerializeField]
    private Transform openCoordinate;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (open && !complete)
        {
            OpenDoor();
        }
    }

    private void OpenDoor()
    {
        transform.position = Vector2.MoveTowards(transform.position, openCoordinate.position, 5 * Time.deltaTime);
        if (transform.position == openCoordinate.position)
        {
            complete = true;
        }
    }
}
