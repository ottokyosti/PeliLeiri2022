using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeAttack : MonoBehaviour
{
    [SerializeField]
    private Collider2D hitbox;
    private bool attacking = false;

    [SerializeField]
    private float attackDuration = 0.3f;
    private float attackDurationtemp;
    [SerializeField] private GameObject explosion;
    [SerializeField] private GameObject explosionSound;

    void Start()
    {
        attackDurationtemp = attackDuration;
    }

    void Update()
    {
        if(attacking)
        {
            attackDurationtemp -= Time.deltaTime;
            if(attackDurationtemp <= 0)
            {
                attacking = false;
                hitbox.enabled = false;
                GetComponent<Animator>().SetBool("attack", false);
                attackDurationtemp = attackDuration;
            }
        }
        if (Input.GetKeyDown("space"))
        {
            Debug.Log("swing");
            attacking = true;
            hitbox.enabled = true;
            GetComponent<Animator>().SetBool("attack", true);
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "enemy")
        {
            Instantiate(explosion, col.gameObject.transform.position, col.gameObject.transform.rotation);
            Instantiate(explosionSound, col.gameObject.transform.position, col.gameObject.transform.rotation);
            Destroy(col.gameObject);
        }
    }
}
