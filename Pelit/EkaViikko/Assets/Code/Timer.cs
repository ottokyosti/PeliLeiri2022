using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField, Tooltip("Determines the time (in seconds) after which the environment will change")] private float timer;
    private float timerAmount;
    [SerializeField] private GameObject diggable;
    [SerializeField] private GameObject enemy;
    private int count;

    private void Start()
    {
        timerAmount = timer;
        diggable.GetComponent<Diggable>().state = Diggable.SpriteState.Rock;
        enemy.GetComponent<Enemy>().frontState = Enemy.Front.Magma;
    }

    private void Update()
    {
        if (timer > 0)
        {
            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                if (!(count >= 2))
                {
                    int typeInt = (int) diggable.GetComponent<Diggable>().state + 1;
                    diggable.GetComponent<Diggable>().state = (Diggable.SpriteState) typeInt;
                    typeInt = (int) enemy.GetComponent<Enemy>().frontState + 1;
                    enemy.GetComponent<Enemy>().frontState = (Enemy.Front) typeInt;
                }
                count++;
                timer = timerAmount;
            }
        }
    }
}
