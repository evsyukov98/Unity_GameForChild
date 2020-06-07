using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ItemSlot : MonoBehaviour
{
    public int currentObject;

    public int correctObject;

    public Transform ItemPrefab_1;

    public Transform ItemPrefab_2;

    public Transform ItemPrefab_3;

    public Transform ItemPrefab_4;

    private void Start()
    {
        switch (currentObject)
        {
            case 1:
                Instantiate(ItemPrefab_1, transform).GetComponent<DragItem>().ItemID =1;
                break;
            case 2:
                Instantiate(ItemPrefab_2, transform).GetComponent<DragItem>().ItemID = 2;
                break;
            case 3:
                Instantiate(ItemPrefab_3, transform).GetComponent<DragItem>().ItemID = 3;
                break;
            case 4:
                Instantiate(ItemPrefab_4, transform).GetComponent<DragItem>().ItemID = 4;
                break;
        }
    }

    private void Update()
    {
        
    }


}
