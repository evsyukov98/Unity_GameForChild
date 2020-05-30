using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalBehaviour : MonoBehaviour
{
    public float Speed;
    private float waitTime;
    public float StartWaitTime;

    // список точек куда будет двигаться обьект
    public GameObject[] moveSpots;

    // Случайная цифра для рандомизации к точке движения
    private int randomSpot;

    private void Awake()
    {
        moveSpots = GameObject.FindGameObjectsWithTag("Bush");
    }
    void Start()
    {
        waitTime = StartWaitTime;
        randomSpot = Random.Range(0, moveSpots.Length);
    }

    void Update()
    {
        transform.position = Vector2.MoveTowards(
            transform.position,
            moveSpots[randomSpot].transform.position, 
            Speed* Time.deltaTime);

        if (Vector2.Distance(transform.position, moveSpots[randomSpot].transform.position) < 0.2f)
        {
            if (waitTime <= 0)
            {
                randomSpot = Random.Range(0, moveSpots.Length);
                waitTime = StartWaitTime;
            }
            else
            {
                waitTime -= Time.deltaTime;
            }
        }
    }

    
}
