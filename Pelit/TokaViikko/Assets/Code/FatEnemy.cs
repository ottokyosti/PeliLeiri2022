using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FatEnemy : MonoBehaviour
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
    [SerializeField] private Slider healthSlider;
    private float destroyTime = 10;
    [SerializeField] private GameObject explosionSound;

    void Start()
    {
        healthSlider.gameObject.SetActive(false);
        Debug.Log(transform.up * speed);
        GetComponent<Rigidbody2D>().AddForce(transform.up * speed);
    }

    void Update()
    {
        healthSlider.value = health;
        if (health == 2)
        {
            healthSlider.gameObject.SetActive(true);
        }
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
