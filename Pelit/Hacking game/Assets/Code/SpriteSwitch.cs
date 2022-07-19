using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteSwitch : MonoBehaviour
{
    [SerializeField]
    private Sprite spriteStandard;

    [SerializeField]
    private Sprite spriteManip;

    private ModeSwapSystem system;

    private SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = spriteStandard;
        system = FindObjectOfType<ModeSwapSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        if (system.inManip)
        {
            spriteRenderer.sprite = spriteManip;
        }
        else if (!system.inManip)
        {
            spriteRenderer.sprite = spriteStandard;
        }
    }
}
