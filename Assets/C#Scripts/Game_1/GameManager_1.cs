using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager_1 : MonoBehaviour
{
    public int SpawnTime = 3;

    public int CountOfEnemy = 10;

    public int Goal;

    public GameObject VictoryText;

    // животное которое будет генериться
    public List<GameObject> AnimalPrefabs = new List<GameObject>();

    // Список позиций для спауна животных.
    public List<Transform> SpawnPoints = new List<Transform>();

    IEnumerator Start()
    {
        Guide();

        for (int i = 0; i < CountOfEnemy; i++)
        {
            yield return new WaitForSeconds(SpawnTime);
            CreateAnimals();
        }
    }

    void Update()
    {
        CatchAnimal();

        Victory();
    }

    void CreateAnimals()
    {
        int randomAnimal = Random.Range(0, AnimalPrefabs.Count);

        Transform spawnPoint = SpawnPoints[Random.Range(0,SpawnPoints.Count)];

        GameObject animal = Instantiate(AnimalPrefabs[randomAnimal],spawnPoint);
    }

    void CatchAnimal()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 ray = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            RaycastHit2D hit = Physics2D.Raycast(ray, Vector3.back);

            if (hit.collider != null && hit.transform.tag == "Animal")
            {
                Goal++;
                Destroy(hit.transform.gameObject);
            }
        }
    }

    void Victory()
    {
        if (Goal == 10)
        {
            Text victory = VictoryText.GetComponent<Text>();
            victory.enabled = true;
        }
    }

    void Guide()
    {
        // Здесь будет обучение игры
    }
}
