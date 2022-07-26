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

    [SerializeField] private bool mainmenu;

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
        if (!(mainmenu))
        {
            StartCoroutine(CursorBlinking());
            text = "";
        }
        else
        {
            StartCoroutine(MainMenuWriting("Code Hero"));
            text = "";
        }
        
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
        
        Coroutine lastRoutine = StartCoroutine(CursorBlinkingWholeText(textToWrite));

        if (!(mainmenu))
        {
            yield return new WaitForFixedUpdate();

            StopCoroutine(lastRoutine);

            text = "";

            StartCoroutine(CursorBlinking());
        }
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

    IEnumerator CursorBlinkingWholeText(string textToWrite)
    {
        WaitForSecondsRealtime wait = new WaitForSecondsRealtime(0.5f);
        while (true)
        {
            tmpText.text = textToWrite + "_";
            yield return wait;
            tmpText.text = textToWrite;
            yield return wait;
        }
    }

    IEnumerator MainMenuWriting(string textToWrite)
    {
        Coroutine lastRoutine = StartCoroutine(CursorBlinking());
        yield return new WaitForSecondsRealtime(2f);
        StopCoroutine(lastRoutine);
        for (int i = 0; i < textToWrite.Length; i++)
        {
            text = text + textToWrite[i];
            tmpText.text = text + "_";
            yield return new WaitForSecondsRealtime(writeDelay);
        }
        StartCoroutine(CursorBlinkingWholeText(textToWrite));
    }
}
