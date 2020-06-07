using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragItem : MonoBehaviour , IDragHandler, IBeginDragHandler,IEndDragHandler
{
    public int ItemID;

    private CanvasGroup canvasGroup;

    public static DragItem dragItem;

    public Vector3 startPosition;

    public Transform startParent;

    public RectTransform dragLayer;

    public Transform Slot;

    public Transform currentSlot;

    private void Start()
    {
        canvasGroup = GetComponent<CanvasGroup>();

        dragLayer = GameObject.FindGameObjectWithTag("DragLayer").GetComponent<RectTransform>();
        currentSlot = transform.parent;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        Slot = null;

        dragItem = this;// типа синглтон

        startPosition = transform.position;

        startParent = transform.parent;

        transform.SetParent(dragLayer);

        #region
        // в канвасах работает так - если ты находишься выше
        // (даже если не являешься родителем а всеголишь брат)
        // то и обьект находиться твой выше
        // т.е. твой луч врезается в тебя (если убрать блок рейкаст)
        // то ты становишься прозрачным.
        // а если ты навсегда оставляешь его прозрачным то 
        // тебя не смогут найти другие обьекты.
        // в  дальшейшем могут быть проблемы
        // если на тебя будут падать другие обьекты
        #endregion
        canvasGroup.blocksRaycasts = false;
        canvasGroup.alpha = 0.6f;
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        dragItem = null;
        canvasGroup.blocksRaycasts = true;
        canvasGroup.alpha = 1f;


        // если мы промахулись т.е. новый родитель не назначен
        if (Slot == null)
        {
            transform.SetParent(startParent);
            transform.position = startPosition;
        }

        Slot = null;
    }

    public void SetItemToSlot(Transform slot)
    {
        Slot = slot;
        transform.SetParent(slot);
        currentSlot = slot;
        transform.localPosition = Vector3.zero; 

    }
}
