using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    private Vector2 earlierPosition;
    [SerializeField, Tooltip("Speed which the spawner moves upwards (should be same as camera's speed)")] private float speed;
    [SerializeField, Tooltip("The diggable gameobject that the spawner will spawn")] private GameObject diggable;
    [SerializeField, Tooltip("The gameobject obstacle that the spawner will spawn")] private GameObject obstacle;
    private int[] randArray = new int[4];
    private float xPos = -8.5f;

    private void Start()
    {
        earlierPosition = this.gameObject.transform.position;
    }

    private void Update()
    {
        transform.Translate(Vector2.up * Time.deltaTime * speed);
        if ((int) this.gameObject.transform.position.y == (int) (earlierPosition.y + 1))
        {
            GetNewRandoms();
            for (int i = 0; i < 18; i++)
            {
                if (i == randArray[0] || i == randArray[1] || i == randArray[2] || i == randArray[3])
                {
                    var tempObstacle = Instantiate(obstacle, new Vector2(xPos, this.gameObject.transform.position.y), Quaternion.identity);
                    xPos++;
                }
                else
                {
                    var temp = Instantiate(diggable, new Vector2(xPos, this.gameObject.transform.position.y), Quaternion.identity);
                    xPos++;
                }
            }
            xPos = -8.5f;
            earlierPosition = this.gameObject.transform.position;
        }
    }

    private void GetNewRandoms()
    {
        int count = 0;
        while (true)
        {
            int rand = Random.Range(0, 18);
            randArray[count] = rand;
            count++;
            if (count == randArray.Length)
            {
                break;
            }
        }
    }
}
