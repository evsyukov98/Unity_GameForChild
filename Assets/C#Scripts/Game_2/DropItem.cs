using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DropItem : MonoBehaviour, IDropHandler
{
    public void OnDrop(PointerEventData eventData)
    {
        // взять предмет который сечас перемещается
        // (это можно сделать т.к. он статический) 
        // (для всех он один )
        DragItem item = DragItem.dragItem;

        // у детей текущего обьекта попробовать взять DragItem
        // это будет означать что у него есть дети  
        var childrens = transform.GetComponentsInChildren<DragItem>();

        // если обьект перемещается и у этого обьекта нет детей
        if (item != null && transform.childCount == 0)
        {
            item.SetItemToSlot(transform);
        }
        // если есть дети 
        else if (item != null && childrens.Length > 0)
        {
            var slot = item.currentSlot;
            childrens[0].SetItemToSlot(slot);
            item.SetItemToSlot(transform);
        }
    }
}
