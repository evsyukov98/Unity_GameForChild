using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;


public class GameManager_2 : MonoBehaviour
{
    /// <summary>
    /// Все игровые слоты
    /// </summary>
    [SerializeField] private List<ItemSlot_2> _itemSlots;

    /// <summary>
    /// Слоты которые используются в данной сложности
    /// </summary>
    private List<ItemSlot_2> _usingSlots;

    /// <summary>
    /// Время таймера
    /// </summary>
    public static readonly int StartDelayTime = 4;

    /// <summary>
    /// Вступительное текстовое поле
    /// </summary>
    [SerializeField] private Transform _startText;

    /// <summary>
    /// Текстовое поле таймера
    /// </summary>
    [SerializeField] private Transform _timerText;

    /// <summary>
    /// Текстовое поле победы
    /// </summary>
    [SerializeField] private Transform _winText;

    /// <summary>
    /// Переменная для проверки конца игры 
    /// </summary>
    private bool _endGame = false;

    /// <summary>
    /// Полотно хранит выбор уровня
    /// </summary>
    [SerializeField] private Transform _difficultyCanvas;

    /// <summary>
    /// Сложность
    /// </summary>
    private int _difficulty = 4;

    /// <summary>
    /// Установка сложности
    /// </summary>
    /// <param name="difficulty">от 3 до 6</param>
    public void SetDifficulty(int difficulty)
    {
        if (difficulty < 3)
        {
            _difficulty = 3;
            return;
        }

        if (difficulty > 6)
        {
            _difficulty = 6;
            return;
        }

        _difficulty = difficulty;
        Debug.Log("Сложность выбрана" + _difficulty);
    }

    private void Awake()
    {
        _usingSlots = new List<ItemSlot_2>();

        for (int i = 0; i < _difficulty; i++)
        {
            _usingSlots.Add(_itemSlots[i]);
        }

        SlotFill(_difficulty);

        StartCoroutine(StartTextManager());
    }

    void Update()
    {
        StartCoroutine(EndGameCheker());
    }

    /// <summary>
    /// Проверка на конец игры
    /// </summary>
    private IEnumerator EndGameCheker()
    {
        int slotsCount = _difficulty;

        foreach (ItemSlot_2 item in _usingSlots)
        {
            if (item.GetComponentInChildren<DragItem>() != null)
            {
                if (item.CorrectObject ==
                    item.GetComponentInChildren<DragItem>().ItemID)
                {
                    slotsCount--;
                }
            }
        }

        if (slotsCount == 0 && _endGame == false)
        {
            _endGame = true;

            _winText.gameObject.SetActive(true);

            yield return new WaitForSeconds(2);

            _difficultyCanvas.gameObject.SetActive(true);
        }
    }

    /// <summary>
    /// Перезагрузить игру
    /// </summary>
    /// <returns></returns>
    public void RestartGame(int difficulty)
    {
        SetDifficulty(difficulty);

        Awake();
        
        _difficultyCanvas.gameObject.SetActive(false);

        foreach (ItemSlot_2 item in _itemSlots)
        {
            item.DestroyCreatedPrefab();
        }

        foreach (ItemSlot_2 item in _usingSlots)
        {
            StartCoroutine(item.ReStart());
        }

        _endGame = false;

        _winText.gameObject.SetActive(false);
    }

    /// <summary>
    /// Начальные текста
    /// </summary>
    private IEnumerator StartTextManager()
    {
        _timerText.GetComponent<Text>().text = Convert.ToString(StartDelayTime);

        for (int i = StartDelayTime; i != 0; i--)
        {
            yield return new WaitForSeconds(1);

            _timerText.GetComponent<Text>().text = Convert.ToString(i - 1);
        }

        _timerText.GetComponent<Text>().text = "";

        _startText.gameObject.SetActive(false);
    }

    /// <summary>
    /// Выдает слотам данные о их обьектах (Prefab)
    /// </summary>
    /// <param name="massSize">Кол-во необходимых к заполнению слотов</param>
    private void SlotFill(int massSize)
    {
        int[] correctMass = RandomMass(massSize);

        int[] currentMass = RandomMass(massSize);

        while (correctMass == currentMass)
        {
            currentMass = RandomMass(massSize);
        }

        for (int i = 0; i < _usingSlots.Count; i++)
        {
            _usingSlots[i].CorrectObject = correctMass[i];

            _usingSlots[i].CurrentObject = currentMass[i];
        }
    }

    /// <summary>
    /// Возвращает рандомный массив
    /// </summary>
    /// <param name="size">размеры массива</param>
    private int[] RandomMass(int size)
    {
        int[] newMass = new int[size];

        for (int i = 0; i < newMass.Length; i++)
        {
            bool newNumber = true;

            while (newNumber == true)
            {
                int massSize = size;

                int randomInt = Random.Range(1, size+1);

                foreach (int element in newMass)
                {
                    if (element != randomInt)
                    {
                        massSize--;
                        if (massSize == 0)
                        {
                            newMass[i] = randomInt;
                            newNumber = false;
                        }
                    }
                }
            }
        }
        return newMass;
    }
}
