using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ManipObject : MonoBehaviour
{
    private GameObject player;
    [SerializeField]
    private float force = 50;
    [SerializeField]
    private bool shrunk = false;
    private Vector3 scale;
    private ModeSwapSystem modeSwapSystem;
    private bool manipPerformed = false;
    [SerializeField]
    private GameObject crushBelow;
    [SerializeField]
    private GameObject crushAbove;

    private GameObject gravityIcon;
    private GameObject pushIcon;
    private GameObject pullIcon;
    private GameObject sizeIcon;

    void Start()
    {
        gravityIcon = transform.Find("GravityIcon").gameObject;
        pushIcon = transform.Find("PushIcon").gameObject;
        pullIcon = transform.Find("PullIcon").gameObject;
        sizeIcon = transform.Find("SizeIcon").gameObject;
        scale = transform.localScale;
        player = GameObject.FindGameObjectWithTag("Player");
        modeSwapSystem = FindObjectOfType<ModeSwapSystem>();
        if (crushBelow != null && crushAbove != null)
        {
            if (GetComponent<Rigidbody2D>().gravityScale > 0)
            {
                crushBelow.SetActive(true);
                crushAbove.SetActive(false);
            }
            else if (GetComponent<Rigidbody2D>().gravityScale < 0)
            {
                crushAbove.SetActive(true);
                crushBelow.SetActive(false);
            }
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab) && modeSwapSystem.inManip)
        {
            manipPerformed = false;
            gravityIcon.SetActive(false);
            pushIcon.SetActive(false);
            pullIcon.SetActive(false);
            sizeIcon.SetActive(false);
        }
    }

    void OnMouseDown()
    {
        if (modeSwapSystem.inManip && !manipPerformed)
        {
            if (modeSwapSystem.CurrentManip == ModeSwapSystem.AppliedManip.first)
            {
                gravityIcon.SetActive(true);
                FlipGravity();
                manipPerformed = true;
            }
            else if (modeSwapSystem.CurrentManip == ModeSwapSystem.AppliedManip.second)
            {
                pushIcon.SetActive(true);
                ForceAdd(true);
                manipPerformed = true;
            }
            else if (modeSwapSystem.CurrentManip == ModeSwapSystem.AppliedManip.third)
            {
                pullIcon.SetActive(true);
                ForceAdd(false);
                manipPerformed = true;
            }
            else if (modeSwapSystem.CurrentManip == ModeSwapSystem.AppliedManip.fourth)
            {
                sizeIcon.SetActive(true);
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
                manipPerformed = true;
            }
        }
    }

    private void FlipGravity()
    {
        if (GetComponent<Rigidbody2D>().gravityScale > 0)
        {
            TextWriter.codeText.WriteText("Rigidbody2D.gravityScale = -1;");
        }
        else
        {
            TextWriter.codeText.WriteText("Rigidbody2D.gravityScale = 1;");
        }

        GetComponent<Rigidbody2D>().gravityScale *= -1;
        if (crushBelow != null && crushAbove != null)
        {
            if (GetComponent<Rigidbody2D>().gravityScale > 0)
            {
                crushBelow.SetActive(true);
                crushAbove.SetActive(false);
            }
            else if (GetComponent<Rigidbody2D>().gravityScale < 0)
            {
                crushAbove.SetActive(true);
                crushBelow.SetActive(false);
            }
        }
    }

    private void ForceAdd(bool forward)
    {
        if (forward)
        {
            Debug.Log("forward");
            TextWriter.codeText.WriteText("Rigidbody2d.AddForce(10);");
            GetComponent<Rigidbody2D>().AddForce(new Vector3(1, 0, 0) * force);
        }
        else
        {
            Debug.Log("back");
            TextWriter.codeText.WriteText("Rigidbody2d.AddForce(-10);");
            GetComponent<Rigidbody2D>().AddForce(new Vector3(-1, 0, 0) * force);
        }
    }

    private IEnumerator Shrink()
    {
        TextWriter.codeText.WriteText("gameObject.transform.localScale = 0.5f;");
        Vector3 startScale = transform.localScale;
        Vector3 targetScale = new Vector3(0.5f * startScale.x, 0.5f * startScale.y, 0.5f * startScale.z);
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
        TextWriter.codeText.WriteText("gameObject.transform.localScale = 1f;");
        Vector3 startScale = transform.localScale;
        Vector3 targetScale = new Vector3(scale.x, scale.y, scale.z);
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
