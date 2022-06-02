using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleBackground : MonoBehaviour
{
    [SerializeField] private Sprite[] itemBackgrounds;
    [SerializeField] private GameObject child;

    private void Start()
    {
        switch (GetComponent<Diggable>().state)
        {
            case (Diggable.SpriteState.Rock):
                child.GetComponent<SpriteRenderer>().sprite = itemBackgrounds[0];
                break;
            
            case (Diggable.SpriteState.Dirt):
                child.GetComponent<SpriteRenderer>().sprite = itemBackgrounds[1];
                break;

            case (Diggable.SpriteState.Sand):
                child.GetComponent<SpriteRenderer>().sprite = itemBackgrounds[2];
                break;
        }
    }
}
