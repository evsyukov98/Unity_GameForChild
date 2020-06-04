using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ItemSlot : MonoBehaviour, IDropHandler
{
    // что-то падает на предмет
    public void OnDrop(PointerEventData eventData)
    {
        Debug.Log("OnDrop");

        // если что-то упало на это
        if (eventData.pointerDrag != null)
        {
            // поменять позицию упавшего предмета на позицию этого предмета
            eventData.pointerDrag.GetComponent<RectTransform>()
                    .anchoredPosition =
                GetComponent<RectTransform>().anchoredPosition;
        }
    }
}
