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
    [SerializeField]
    private GameObject crushBelow;
    [SerializeField]
    private GameObject crushAbove;

    private AudioSource audioSource;

    private GameObject gravityIcon;
    private GameObject pushIcon;
    private GameObject pullIcon;
    private GameObject sizeIcon;

    private bool flipGravity = false;
    private bool push = false;
    private bool pull = false;
    private bool shrink = false;
    private bool grow = false;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
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
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            gravityIcon.SetActive(false);
            pushIcon.SetActive(false);
            pullIcon.SetActive(false);
            sizeIcon.SetActive(false);
            if (flipGravity)
            {
                flipGravity = false;
                FlipGravity();
            }
            else if (push)
            {
                push = false;
                ForceAdd(true);
            }
            else if (pull)
            {
                pull = false;
                ForceAdd(false);
            }
            else if (shrink)
            {
                shrink = false;
                StartCoroutine(Shrink());
            }
            else if (grow)
            {
                grow = false;
                StartCoroutine(Grow());
            }
        }
    }

    void OnMouseDown()
    {
        if (modeSwapSystem.inManip)
        {
            if (modeSwapSystem.CurrentManip == ModeSwapSystem.AppliedManip.first)
            {
                audioSource.Play();
                gravityIcon.SetActive(true);
                pushIcon.SetActive(false);
                pullIcon.SetActive(false);
                sizeIcon.SetActive(false);
                flipGravity = true;
                push = false;
                pull = false;
                shrink = false;
                grow = false;
                if (GetComponent<Rigidbody2D>().gravityScale > 0)
                {
                    TextWriter.codeText.WriteText("Rigidbody2D.gravityScale = -1;");
                }
                else
                {
                    TextWriter.codeText.WriteText("Rigidbody2D.gravityScale = 1;");
                }
            }
            else if (modeSwapSystem.CurrentManip == ModeSwapSystem.AppliedManip.second)
            {
                audioSource.Play();
                gravityIcon.SetActive(false);
                pushIcon.SetActive(true);
                pullIcon.SetActive(false);
                sizeIcon.SetActive(false);
                flipGravity = false;
                push = true;
                pull = false;
                shrink = false;
                grow = false;
                TextWriter.codeText.WriteText("Rigidbody2d.AddForce(10);");
            }
            else if (modeSwapSystem.CurrentManip == ModeSwapSystem.AppliedManip.third)
            {
                audioSource.Play();
                gravityIcon.SetActive(false);
                pushIcon.SetActive(false);
                pullIcon.SetActive(true);
                sizeIcon.SetActive(false);
                flipGravity = false;
                push = false;
                pull = true;
                shrink = false;
                grow = false;
                TextWriter.codeText.WriteText("Rigidbody2d.AddForce(-10);");
            }
            else if (modeSwapSystem.CurrentManip == ModeSwapSystem.AppliedManip.fourth)
            {
                audioSource.Play();
                gravityIcon.SetActive(false);
                pushIcon.SetActive(false);
                pullIcon.SetActive(false);
                sizeIcon.SetActive(true);
                if (!shrunk)
                {
                    shrunk = true;
                    flipGravity = false;
                    push = false;
                    pull = false;
                    shrink = true;
                    grow = false;
                    TextWriter.codeText.WriteText("gameObject.transform.localScale = 0.5f;");
                }
                else if (shrunk)
                {
                    shrunk = false;
                    flipGravity = false;
                    push = false;
                    pull = false;
                    shrink = false;
                    grow = true;
                    TextWriter.codeText.WriteText("gameObject.transform.localScale = 1f;");
                }
            }
        }
    }

    private void FlipGravity()
    {
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
            GetComponent<Rigidbody2D>().AddForce(new Vector3(1, 0, 0) * force);
        }
        else
        {
            Debug.Log("back");
            GetComponent<Rigidbody2D>().AddForce(new Vector3(-1, 0, 0) * force);
        }
    }

    private IEnumerator Shrink()
    {
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
