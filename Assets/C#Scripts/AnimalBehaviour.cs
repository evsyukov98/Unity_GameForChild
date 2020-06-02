using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalBehaviour : MonoBehaviour
{
    public float Speed;
    private float _waitTime;
    public float StartWaitTime;

    // список точек куда будет двигаться обьект
    public GameObject[] moveSpots;

    // Случайная цифра для рандомизации к точке движения
    private int _randomSpot;

    private void Awake()
    {
        moveSpots = GameObject.FindGameObjectsWithTag("Bush");
    }
    void Start()
    {
        _waitTime = StartWaitTime;
        _randomSpot = Random.Range(0, moveSpots.Length);
    }

    void Update()
    {
        MoveToBush();
    }

    void MoveToBush()
    {
        transform.position = Vector2.MoveTowards(
            transform.position,
            moveSpots[_randomSpot].transform.position,
            Speed * Time.deltaTime);

        if (Vector2.Distance(transform.position, moveSpots[_randomSpot].transform.position) < 0.2f)
        {
            if (_waitTime <= 0)
            {
                _randomSpot = Random.Range(0, moveSpots.Length);
                _waitTime = StartWaitTime;
            }
            else
            {
                _waitTime -= Time.deltaTime;
            }
        }
    }

    //public void GoalUP()
    //{
    //    GameObject gameObject = GameObject.FindGameObjectWithTag("GameManager");

    //    GameManager_1 gameManager_1 = gameObject.GetComponent<GameManager_1>();

    //    gameManager_1.Goal++;
    //}

    //private void OnMouseDown()
    //{
    //    GoalUP();
    //    Destroy(this.gameObject);
    //}

}
