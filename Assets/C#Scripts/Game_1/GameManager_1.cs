using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager_1 : MonoBehaviour
{
    // счетчик
    private int _goal;

    // животное которое будет генериться
    public List<GameObject> AnimalPrefabs = new List<GameObject>();

    // Список позиций для спауна животных.
    public List<Transform> SpawnPoints = new List<Transform>();

    void Start()
    {
        Guide();

        CreateAnimals();

    }

    void Guide()
    {
        // Здесь будет обучение игры
    }

    //TODO: Нужно добавить flip
    void CreateAnimals()
    {
        int randomAnimal = Random.Range(0, AnimalPrefabs.Count);

        Transform spawnPoint = SpawnPoints[Random.Range(0,SpawnPoints.Count)];

        Instantiate(AnimalPrefabs[randomAnimal],spawnPoint);
    }

    void GoalOfVictory()
    {
        // отслеживание прогресса игры
        // после 5, 10, 20 нажатий на цель
        // будет заканчиваться игра
    }
}
