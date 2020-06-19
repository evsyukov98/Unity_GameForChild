using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ItemSlot : MonoBehaviour
{
    public int currentObject;

    public int correctObject;

    public List<Transform> ItemPrefabs;

    public List<Transform> TempPrefabs;


    private IEnumerator Start()
    {
        Transform tempPrefab;
        switch (correctObject)
        {
            case 1:
                tempPrefab= Instantiate(TempPrefabs[0], transform);
                break;
            case 2:
                tempPrefab = Instantiate(TempPrefabs[1], transform);
                break;
            case 3:
                tempPrefab = Instantiate(TempPrefabs[2], transform);
                break;
            case 4:
                tempPrefab = Instantiate(TempPrefabs[3], transform);
                break;
            default:
                tempPrefab = null;
                break;
        }
        yield return new WaitForSeconds(3);

        if (tempPrefab != null)
        {
            Destroy(tempPrefab.gameObject);
        }


        switch (currentObject)
        {
            case 1:
                Instantiate(ItemPrefabs[0], transform).GetComponent<DragItem>().ItemID = 1;
                break;
            case 2:
                Instantiate(ItemPrefabs[1], transform).GetComponent<DragItem>().ItemID = 2;
                break;
            case 3:
                Instantiate(ItemPrefabs[2], transform).GetComponent<DragItem>().ItemID = 3;
                break;
            case 4:
                Instantiate(ItemPrefabs[3], transform).GetComponent<DragItem>().ItemID = 4;
                break;
        }
    }

    private void Update()
    {
        
    }


}
