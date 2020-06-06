using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DropItem : MonoBehaviour, IDropHandler
{
    // если чтото упало сюда,
    public void OnDrop(PointerEventData eventData)
    {
        // взять предмет который сечас перемещается
        // (это можно сделать т.к. он статический) 
        // (для всех он один )
        DragItem item = DragItem.dragItem;

        // и если он еще не прекратил перемещаться
        if (item != null && transform.childCount ==0)
        {
            item.SetItemToSlot(transform);
        }
    }
}
