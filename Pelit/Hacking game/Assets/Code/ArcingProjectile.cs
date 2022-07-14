using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArcingProjectile : MonoBehaviour
{
    private Vector2 targetPos;
    public Vector2 _targetPos
    {
        get { return targetPos; }
        set { targetPos = value; }
    }

    [SerializeField] private float speed;

    [SerializeField] private float arcHeight;

    [SerializeField] private GameObject explosionSprite;

    private Vector2 startPos;

    private CircleCollider2D circleCol;

    private bool canMove = true;

    private float explosionTimer = 3f;

    private SpriteRenderer spriteRenderer;

    private void Start()
    {
        startPos = transform.position;
        circleCol = GetComponent<CircleCollider2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        circleCol.enabled = false;
    }

    private void Update()
    {
        if (canMove)
        {
            Vector2 nextPos;
            float startX = startPos.x;
            float targetX = targetPos.x;
            float distance = targetX - startX;
            float nextX = Mathf.MoveTowards(transform.position.x, targetX, speed * Time.deltaTime);
            float baseY = Mathf.Lerp(startPos.y, targetPos.y, (nextX - startX) / distance);
            float arc = arcHeight * (nextX - startX) * (nextX - targetX) / (-0.25f * distance * distance);
            nextPos = new Vector2(nextX, baseY + arc);
            transform.position = nextPos;

            if (nextPos == targetPos)
            {
                canMove = false;
                circleCol.enabled = true;
                StartCoroutine(ExplosionStart());
            }
        }
    }

    IEnumerator ExplosionStart()
    {
        WaitForSecondsRealtime wait = new WaitForSecondsRealtime(1f);
        yield return wait;
        spriteRenderer.color = Color.yellow;
        yield return wait;
        spriteRenderer.color = Color.white;
        yield return wait;
        Instantiate(explosionSprite, transform.position, transform.rotation);
        Destroy(this.gameObject);
    }
}
