using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{    
    public int points;

    [SerializeField]
    private float speed = 1000f;
    [SerializeField] private float health;
    public float _health
    {
        get { return health; }
        set { health = value; }
    }
    private float destroyTime = 10;
    [SerializeField] private GameObject explosionSound;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(transform.up * speed);
        GetComponent<Rigidbody2D>().AddForce(transform.up * speed);
    }

    // Update is called once per frame
    void Update()
    {
        if (health == 0)
        {
            Instantiate(explosionSound, transform.position, transform.rotation);
            Destroy(this.gameObject);
        }
        destroyTime -= Time.deltaTime;
        if(destroyTime <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}
