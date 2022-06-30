using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class OpenManipMenu : MonoBehaviour, IPointerDownHandler
{
    [SerializeField]
    private GameObject menu;
    private GameObject spawnedMenu;

    public void OnPointerDown(PointerEventData eventData)
    {
        if(spawnedMenu == null)
        {
            spawnedMenu = Instantiate(menu, new Vector3(transform.position.x, transform.position.y + 2, 0), transform.rotation, transform);
        }
        else if(spawnedMenu != null)
        {
            Destroy(spawnedMenu);
        }
    }
}
