using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager_3 : MonoBehaviour
{
    [SerializeField] public List<ItemSlot_3> ItemSlots;

    [SerializeField] public Transform WinText;

    private AudioSource _audioSource;

    private void Update()
    {
        CatchAnimal();
    }

    private void Start()
    {
        SlotFill(ItemSlots);
        _audioSource = GetComponent<AudioSource>();
    }

    
    void SlotFill(List<ItemSlot_3> slots)
    {
        int randCorrectType = Random.Range(0, (int)ItemSlot_3.EnemyType.MaxSize);

        int randWrongType = Random.Range(0, (int)ItemSlot_3.EnemyType.MaxSize);

        int randSlot = Random.Range(0, slots.Count);

        while (randCorrectType == randWrongType)
        {
            randWrongType= Random.Range(0,(int)ItemSlot_3.EnemyType.MaxSize);
        }

        for (int i = 0; i < slots.Count; i++)
        {
            if (randSlot == i)
            {
                slots[i].CreatePrefab((ItemSlot_3.EnemyType)randWrongType,i);

                slots[i].CurrentPrefab.tag = "WrongAnimal";
                continue;
            }

            slots[i].CreatePrefab((ItemSlot_3.EnemyType) randCorrectType, i);
        }
    }

    void CatchAnimal()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 ray = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            RaycastHit2D hit = Physics2D.Raycast(ray, Vector3.back);

            if (hit.collider != null && hit.transform.tag == "WrongAnimal")
            {
                Destroy(hit.transform.gameObject);
                StartCoroutine(WinHandler());
                _audioSource.Play();
            }
        }
    }

    IEnumerator WinHandler()
    {
        WinText.GetComponent<Text>().text = "Молодец ";

        yield return new WaitForSeconds(1);

        WinText.GetComponent<Text>().text = "";

        GameObject[] gameObjects =
            GameObject.FindGameObjectsWithTag("CorrectAnimal");
        

        foreach (GameObject enemy in gameObjects)
        {
            Destroy(enemy);
        }

        SlotFill(ItemSlots);

    }
}
