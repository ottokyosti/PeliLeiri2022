using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrenadierEnemy : MonoBehaviour
{
    [SerializeField] private float radius;

    private Vector2 spawnPlace;

    [SerializeField] private LayerMask targetLayer;

    private GameObject playerRef;

    private bool playerInRange;

    [SerializeField] private float fireDelay;
        
    private float timeBtwShots;

    [SerializeField] private GameObject projectile;

    private void Start()
    {
        playerRef = GameObject.FindGameObjectWithTag("Player");
        StartCoroutine(FOVCheck());   
    }

    private void Update()
    {
        if (playerInRange)
        {
            if (playerRef.transform.position.x < transform.position.x)
            {   
                transform.localScale = new Vector2(Mathf.Abs(transform.localScale.x), transform.localScale.x);
                spawnPlace = Vector2.left;
            }
            else if (playerRef.transform.position.x > transform.position.x)
            {
                transform.localScale = new Vector2(-(Mathf.Abs(transform.localScale.x)), transform.localScale.y);
                spawnPlace = Vector2.right;
            }

            if (timeBtwShots <= 0)
            {
                var tempProjectile = Instantiate(projectile, (Vector2) transform.position + spawnPlace, Quaternion.identity);
                tempProjectile.GetComponent<ArcingProjectile>()._targetPos = playerRef.transform.position;
                timeBtwShots = fireDelay;
            }
            else
            {
                timeBtwShots -= Time.deltaTime;
            }
        }
    }

    IEnumerator FOVCheck()
    {
        WaitForSeconds wait = new WaitForSeconds(0.2f);

        while (true)
        {
            yield return wait;
            FOV();
        }
    }

    private void FOV()
    {
        Collider2D[] rangeCheck = Physics2D.OverlapCircleAll(transform.position, radius, targetLayer);

        if (rangeCheck.Length > 0)
        {
            playerInRange = true;
        }
        else if (playerInRange)
        {
            playerInRange = false;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.black;
        //UnityEditor.Handles.DrawWireDisc(transform.position, Vector3.forward, radius);

        if (playerInRange)
        {
            Gizmos.color = Color.green;
            Gizmos.DrawLine(transform.position, playerRef.transform.position);
        }
    }
}
