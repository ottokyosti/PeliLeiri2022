using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ManipButton : MonoBehaviour, IPointerDownHandler
{
    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log(gameObject.tag);
        if(gameObject.tag == "gravityButton")
        {
            Debug.Log("click1");
            GetComponentInParent<ManipObject>().FlipGravity();
        }
        else if(gameObject.tag == "forceButton")
        {
            Debug.Log("click2");
            GetComponentInParent<ManipObject>().ForceAdd();
        }
    }
}
