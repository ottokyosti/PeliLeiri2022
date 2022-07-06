using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManipObject : MonoBehaviour
{
    private GameObject player;
    [SerializeField]
    private float force = 50;
    private bool shrunk = false;
    private Vector3 scale;
    private ModeSwapSystem modeSwapSystem;

    void Start()
    {
        scale = transform.localScale;
        player = GameObject.FindGameObjectWithTag("Player");
        modeSwapSystem = FindObjectOfType<ModeSwapSystem>();
    }

    void OnMouseDown()
    {
        if (modeSwapSystem.inManip)
        {
            if(modeSwapSystem.CurrentManip == ModeSwapSystem.AppliedManip.first)
            {
                FlipGravity();
            }
            else if(modeSwapSystem.CurrentManip == ModeSwapSystem.AppliedManip.second)
            {
                ForceAdd();
            }
            else if(modeSwapSystem.CurrentManip == ModeSwapSystem.AppliedManip.third)
            {
                if (!shrunk)
                {
                    shrunk = true;
                    StartCoroutine(Shrink());
                }
                else if (shrunk)
                {
                    shrunk = false;
                    StartCoroutine(Grow());
                }
            }
            else if(modeSwapSystem.CurrentManip == ModeSwapSystem.AppliedManip.fourth)
            {
                
            }
        }
    }

    private void FlipGravity()
    {
        GetComponent<Rigidbody2D>().gravityScale *= -1;
    }

    private void ForceAdd()
    {
        if(player.transform.position.x <= gameObject.transform.position.x)
        {
            Debug.Log("forward");
            GetComponent<Rigidbody2D>().AddForce(new Vector3(1,0,0) * force);
        }
        else
        {
            Debug.Log("back");
            GetComponent<Rigidbody2D>().AddForce(new Vector3(-1,0,0) * force);   
        }
    }

    private IEnumerator Shrink()
    {
        Vector3 startScale = transform.localScale;
        Vector3 targetScale = new Vector3(0.5f, 0.5f, 0.5f);
        float timer = 0;
        while (timer < 1)
        {
            timer += Time.deltaTime;
            float t = timer;
            t = t * t * t * (t * (6f * t - 15f) + 10f);
            transform.localScale = Vector3.Lerp(startScale, targetScale, t);
            Debug.Log(transform.localScale);
            yield return null;
        }
        yield return null;
    }

    private IEnumerator Grow()
    {
        Vector3 startScale = transform.localScale;
        Vector3 targetScale = new Vector3(1, 1, 1);
        float timer = 0;
        while (timer < 1)
        {
            timer += Time.deltaTime;
            float t = timer;
            t = t * t * t * (t * (6f * t - 15f) + 10f);
            transform.localScale = Vector3.Lerp(startScale, targetScale, t);
            yield return null;
        }
        yield return null;
    }
}
