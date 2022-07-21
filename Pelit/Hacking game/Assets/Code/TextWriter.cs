using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextWriter : MonoBehaviour
{

    public static TextWriter codeText;

    [SerializeField] private float writeDelay;

    private string text;

    private TMP_Text tmpText;

    private void Start()
    {
        if (codeText == null)
        {
            codeText = this;
        }
        else if (codeText != null)
        {
            Destroy(this.gameObject);
        }

        tmpText = GetComponent<TMP_Text>();
        StartCoroutine(CursorBlinking());
        text = "";
    }

    public void WriteText(string textToWrite)
    {
        StopAllCoroutines();
        text = "";
        StartCoroutine(Write(textToWrite));
    }

    IEnumerator Write(string textToWrite)
    {
        for (int i = 0; i < textToWrite.Length; i++)
        {
            text = text + textToWrite[i];
            tmpText.text = text + "_";
            yield return new WaitForSecondsRealtime(writeDelay);
        }
        
        yield return new WaitForFixedUpdate();
        
        text = "";

        StartCoroutine(CursorBlinking());
    }

    IEnumerator CursorBlinking()
    {
        WaitForSecondsRealtime wait = new WaitForSecondsRealtime(0.5f);
        while (true)
        {
            tmpText.text = "_";
            yield return wait;
            tmpText.text = "";
            yield return wait;
        }
    }
}
