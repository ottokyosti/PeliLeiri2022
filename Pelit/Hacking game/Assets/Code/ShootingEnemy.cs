using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingEnemy : MonoBehaviour
{
    [SerializeField] private GameObject projectile;

    [SerializeField] private float fireDelay;

    private float timeBtwShots;

    private GameObject player;

    private Vector3 playerPosition;

    private Vector3 direction;

    private void Update()
    {
        if (player == null) { return; }
        playerPosition = player.transform.position;
        direction = playerPosition - transform.position;
        if (player.transform.position.x < transform.position.x)
        {   
            transform.localScale = new Vector2(Mathf.Abs(transform.localScale.x), transform.localScale.x);
        }
        else if (player.transform.position.x > transform.position.x)
        {
            transform.localScale = new Vector2(-(Mathf.Abs(transform.localScale.x)), transform.localScale.y);
        }

        if (timeBtwShots <= 0)
        {
            var tempProjectile = Instantiate(projectile, transform.position + direction.normalized, Quaternion.identity);
            tempProjectile.GetComponent<Projectile>()._direction = direction;
            timeBtwShots = fireDelay;
        }
        else
        {
            timeBtwShots -= Time.deltaTime;
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            player = col.gameObject;
        }
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            player = null;
        }
    }
}
