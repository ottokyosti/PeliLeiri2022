using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    [SerializeField]
    private float speed = 1000f;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(transform.up * speed);
        GetComponent<Rigidbody2D>().AddForce(transform.up * speed);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
