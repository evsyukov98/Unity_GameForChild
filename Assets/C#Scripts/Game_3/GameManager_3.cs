using System.Collections.Generic;
using UnityEngine;

public class GameManager_3 : MonoBehaviour
{
    public List<ItemSlot_3> itemSlots;

    private void Update()
    {
        
    }

    private void Start()
    {
        SlotFill(itemSlots);
    }

    
    void SlotFill(List<ItemSlot_3> slots)
    {
        int randCorrectType = Random.Range(0, (int)ItemSlot_3.prefabType.MaxSize);
        int randWrongType = Random.Range(0, (int)ItemSlot_3.prefabType.MaxSize);

        int randSlot = Random.Range(0, slots.Count);

        while (randCorrectType == randWrongType)
        {
            randWrongType= Random.Range(0,(int)ItemSlot_3.prefabType.MaxSize);
        }


        for (int i = 0; i < slots.Count; i++)
        {
            if (randSlot == i)
            {
                slots[i].CreatePrefab((ItemSlot_3.prefabType)randWrongType,i);
                continue;
            }

            slots[i].CreatePrefab((ItemSlot_3.prefabType) randCorrectType, i);
        }
    }
}
