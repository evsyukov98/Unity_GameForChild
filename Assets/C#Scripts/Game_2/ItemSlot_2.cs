using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ItemSlot_2 : MonoBehaviour
{
    public int CurrentObject;

    public int CorrectObject;

    [SerializeField] public List<Transform> ItemPrefabs;

    [SerializeField] public List<Transform> TempPrefabs;

    private Transform _createdPrefab;

    private void Start()
    {
        StartCoroutine(ReStart());
    }

    /// <summary>
    /// Уничтожить обьект который был создан на этой клетке
    /// </summary>
    public void DestroyCreatedPrefab()
    {
        if(_createdPrefab != null)
            Destroy(_createdPrefab.gameObject);
    }

    /// <summary>
    /// Перезагрузить обьект
    /// </summary>
    public IEnumerator ReStart()
    {
        if (CurrentObject == 0 && CorrectObject == 0)
        {
            yield break;
        }

        Transform tempPrefab =
            Instantiate(TempPrefabs[CorrectObject - 1], transform);
        yield return new WaitForSeconds(GameManager_2.StartDelayTime);

        if (tempPrefab != null)
            Destroy(tempPrefab.gameObject);

        _createdPrefab =
            Instantiate(ItemPrefabs[CurrentObject - 1], transform);
        _createdPrefab.GetComponent<DragItem>().ItemID = CurrentObject;
    }
}
