using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager_1 : MonoBehaviour
{
    private int _spawnTime = 1;

    private int _startDelayTime = 3;

    private int _countOfEnemy = 7;

    private int _goal = 0;

    public GameObject VictoryText;

    public GameObject EnemyPrefab;

    public GameObject FakePrefab;

    public List<Sprite> AllSprites;

    private int _enemySpriteNumber;

    public List<int> OtherSpriteNumbers;

    public List<Transform> SpawnPoints = new List<Transform>();

    public Transform GuideImage;

    void Start()
    {
        RandomImageHandler();

        StartCoroutine(Guide());

        StartCoroutine(CreateAllUnits());
    }

    void Update()
    {
        CatchAnimal();

        Victory();
    }

    IEnumerator CreateAllUnits()
    {
        yield return new WaitForSeconds(_startDelayTime);

        for (int i = 0; i < _countOfEnemy; i++)
        {
            yield return new WaitForSeconds(_spawnTime);
            CreateEnemy();
            CreateFake();
        }
    }

    void RandomImageHandler()
    {
        _enemySpriteNumber = Random.Range(0, AllSprites.Count);

        for (int i= 0 ; i < AllSprites.Count; i++)
        {
            int randomInt = i;

            if (_enemySpriteNumber != randomInt)
            {
                OtherSpriteNumbers.Add(randomInt);
            }
        }
    }

    void CreateEnemy()
    {
        Transform spawnPoint = SpawnPoints[Random.Range(0,SpawnPoints.Count)];

        GameObject animal = Instantiate(EnemyPrefab,spawnPoint);

        animal.GetComponent<SpriteRenderer>().sprite = 
            AllSprites[_enemySpriteNumber];
    }

    void CreateFake()
    {
        Transform spawnPoint = SpawnPoints[Random.Range(0, SpawnPoints.Count)];

        GameObject animal = Instantiate(FakePrefab, spawnPoint);

        animal.GetComponent<SpriteRenderer>().sprite =
            AllSprites[OtherSpriteNumbers[Random.Range(0,OtherSpriteNumbers.Count)]];
    }

    void CatchAnimal()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 ray = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            RaycastHit2D hit = Physics2D.Raycast(ray, Vector3.back);

            if (hit.collider != null && hit.transform.tag == "Animal")
            {
                _goal++;
                Destroy(hit.transform.gameObject);
            }
        }
    }

    void Victory()
    {
        if (_goal == _countOfEnemy)
        {
            VictoryText.gameObject.SetActive(true);
        }
    }

    IEnumerator Guide()
    {
        GuideImage.GetComponent<Image>().sprite =
            AllSprites[_enemySpriteNumber];
        GuideImage.GetComponent<Image>().preserveAspect = true;

        yield return new WaitForSeconds(_startDelayTime);

        GuideImage.gameObject.SetActive(false);

    }
}
