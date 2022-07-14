using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingEnemyFOV : MonoBehaviour
{
    [SerializeField] private float radius;

    private Vector2 directionToTarget;

    [SerializeField] private LayerMask targetLayer;

    [SerializeField] private LayerMask obstacleLayer;

    private GameObject playerRef;

    private bool CanSeePlayer;

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
        if (CanSeePlayer)
        {
            if (playerRef.transform.position.x < transform.position.x)
            {   
                transform.localScale = new Vector2(Mathf.Abs(transform.localScale.x), transform.localScale.x);
            }
            else if (playerRef.transform.position.x > transform.position.x)
            {
                transform.localScale = new Vector2(-(Mathf.Abs(transform.localScale.x)), transform.localScale.y);
            }

            if (timeBtwShots <= 0)
            {
                var tempProjectile = Instantiate(projectile, (Vector2) transform.position + directionToTarget, Quaternion.identity);
                tempProjectile.GetComponent<Projectile>()._direction = directionToTarget;
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
            Transform target = rangeCheck[0].transform;
            directionToTarget = (target.position - transform.position).normalized;
            float distanceToTarget = Vector2.Distance(transform.position, target.position);

            if (!(Physics2D.Raycast(transform.position, directionToTarget, distanceToTarget, obstacleLayer)))
            {
                CanSeePlayer = true;
            }
            else 
            {
                CanSeePlayer = false;
            }
        }
        else if (CanSeePlayer)
        {
            CanSeePlayer = false;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.black;
        UnityEditor.Handles.DrawWireDisc(transform.position, Vector3.forward, radius);

        if (CanSeePlayer)
        {
            Gizmos.color = Color.green;
            Gizmos.DrawLine(transform.position, playerRef.transform.position);
        }
    }
}
