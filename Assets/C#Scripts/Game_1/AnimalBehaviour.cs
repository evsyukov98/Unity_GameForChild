using UnityEngine;

public class AnimalBehaviour : MonoBehaviour
{
    [SerializeField] private float _speed =5;
    private float _waitTime;
    [SerializeField] private float _startWaitTime = 2;

    private GameObject[] _moveSpots;

    private int _randomSpot;

    private void Awake()
    {
        _moveSpots = GameObject.FindGameObjectsWithTag("Bush");
    }
    void Start()
    {
        _waitTime = _startWaitTime;
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
            _speed * Time.deltaTime);

        

        float moveDir = transform.position.y -
                  _moveSpots[_randomSpot].transform.position.y;

        if (Vector2.Distance(transform.position, _moveSpots[_randomSpot].transform.position) < 0.2f)
        {
            if (_waitTime <= 0)
            {
                _randomSpot = Random.Range(0, _moveSpots.Length);
                _waitTime = _startWaitTime;
            }
            else
            {
                _waitTime -= Time.deltaTime;
            }
        }
    }
}
