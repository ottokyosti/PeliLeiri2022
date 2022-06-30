using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ManipButton : MonoBehaviour, IPointerDownHandler
{
    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("click");
        if(gameObject.tag == "gravityButton")
        {
            GetComponentInParent<ManipObject>().FlipGravity();
        }
    }
}
