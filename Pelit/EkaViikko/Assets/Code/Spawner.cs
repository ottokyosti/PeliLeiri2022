using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    private Vector2 earlierPosition;
    [SerializeField, Tooltip("Speed which the spawner moves upwards (should be same as camera's speed)")] private float speed;
    [SerializeField, Tooltip("The diggable gameobject that the spawner will spawn")] private GameObject diggable;
    [SerializeField, Tooltip("The gameobject obstacle that the spawner will spawn")] private GameObject obstacle;
    [SerializeField, Tooltip("The gameobject enemy that the spawner will spawn")] private GameObject magmaEnemy;
    [SerializeField, Tooltip("The gameobject power up that the spawner will spawn")] private GameObject powerUp;
    [SerializeField, Tooltip("Time between magma enemy spawns (in seconds)")] private float enemyTimer;
    [SerializeField, Tooltip("Minimum time between power up spawns (in seconds)")] private float minPowerUpTimer;
    [SerializeField, Tooltip("Maximum time between power up spawns (in seconds) + 1")] private float maxPowerUpTimer;
    private float powerUpTimer;
    private float enemyTimerOriginal;
    private int[] randArray = new int[4];
    public int[] _randArray
    {
        get { return randArray; }
    }
    private int magmaRand;
    private int powerUpRand;
    private float xPos = -8.5f;

    private void Start()
    {
        earlierPosition = this.gameObject.transform.position;
        enemyTimerOriginal = enemyTimer;
        powerUpTimer = Random.Range(minPowerUpTimer, maxPowerUpTimer);
        magmaRand = Random.Range(0, 18);
        powerUpRand = Random.Range(0, 18);
    }

    private void Update()
    {
        if (enemyTimer > 0)
        {
            enemyTimer -= Time.deltaTime;
        }
        if (powerUpTimer > 0)
        {
            powerUpTimer -= Time.deltaTime;
        }

        transform.Translate(Vector2.up * Time.deltaTime * speed);
        if ((int) this.gameObject.transform.position.y == (int) (earlierPosition.y + 1))
        {
            GetNewRandoms();
            for (int i = 0; i < 18; i++)
            {
                if (i == powerUpRand && powerUpTimer <= 0)
                {
                    var tempPowerUp = Instantiate(powerUp, new Vector2(xPos, this.gameObject.transform.position.y), Quaternion.identity);
                    powerUpRand = Random.Range(0, 18);
                    powerUpTimer = Random.Range(minPowerUpTimer, maxPowerUpTimer);
                    xPos++;
                }
                else if (i == magmaRand && enemyTimer <= 0)
                {
                    var tempMagmaEnemy = Instantiate(magmaEnemy, new Vector2(xPos, this.gameObject.transform.position.y), Quaternion.identity);
                    magmaRand = Random.Range(0, 18);
                    enemyTimer = enemyTimerOriginal;
                    xPos++;
                }
                else if (i == randArray[0] || i == randArray[1] || i == randArray[2] || i == randArray[3])
                {
                    var tempObstacle = Instantiate(obstacle, new Vector2(xPos, this.gameObject.transform.position.y), Quaternion.identity);
                    xPos++;
                }
                else
                {
                    var tempDiggable = Instantiate(diggable, new Vector2(xPos, this.gameObject.transform.position.y), Quaternion.identity);
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
