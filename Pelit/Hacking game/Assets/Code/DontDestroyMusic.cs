using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroyMusic : MonoBehaviour
{
    public static DontDestroyMusic onlyOne;

    private void Awake()
    {
        if (onlyOne == null)
        {
            onlyOne = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else if (onlyOne != null)
        {
            Destroy(this.gameObject);
        }
    }
}
