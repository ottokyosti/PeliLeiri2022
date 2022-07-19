using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextWriter : MonoBehaviour
{

    public static TextWriter codeText;

    [SerializeField] private float writeDelay;

    [SerializeField] private float deleteDelay;

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
        tmpText.text = "_";
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
            yield return new WaitForSeconds(writeDelay);
        }
        
        yield return new WaitForSeconds(1f);

        for (int i = 0; i < textToWrite.Length; i++)
        {
            text = "";
            for (int j = 0; j < textToWrite.Length - i; j++)
            {
                text = text + textToWrite[j];
            }
            tmpText.text = text + "_";
            yield return new WaitForSeconds(deleteDelay);

            if (text.Length == 1)
            {
                tmpText.text = "_";
            }
        }
    }
}
