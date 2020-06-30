using UnityEngine;

public class AnimalBehaviour : MonoBehaviour
{
    public float Speed;
    private float _waitTime;
    public float StartWaitTime;

    // список точек куда будет двигаться обьект
    public GameObject[] _moveSpots;

    // Случайная цифра для рандомизации к точке движения
    private int _randomSpot;

    private void Awake()
    {
        _moveSpots = GameObject.FindGameObjectsWithTag("Bush");
    }
    void Start()
    {
        _waitTime = StartWaitTime;
        _randomSpot = Random.Range(0, _moveSpots.Length);
    }

    void Update()
    {
        MoveToBush();
    }

    void MoveToBush()
    {
        transform.position = Vector2.MoveTowards(
            transform.position,
            _moveSpots[_randomSpot].transform.position,
            Speed * Time.deltaTime);

        

        float moveDir = transform.position.y -
                  _moveSpots[_randomSpot].transform.position.y;

        if (Vector2.Distance(transform.position, _moveSpots[_randomSpot].transform.position) < 0.2f)
        {
            if (_waitTime <= 0)
            {
                _randomSpot = Random.Range(0, _moveSpots.Length);
                _waitTime = StartWaitTime;
            }
            else
            {
                _waitTime -= Time.deltaTime;
            }
        }
    }
}
