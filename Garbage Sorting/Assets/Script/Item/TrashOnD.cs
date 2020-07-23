using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TrashOnD : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public Inventory Bag;
    public Transform originParent;
    public int originID;
    public void OnBeginDrag(PointerEventData eventData)
    {
        originParent = transform.parent;  //获取原始父级
        originID = originParent.GetComponent<Slot>().ID;
        transform.SetParent(originParent.parent);   //在把物体拖出来的时候改变父级,防止遮挡
        transform.position = eventData.position;  //让物体位置随着鼠标改变

        GetComponent<CanvasGroup>().blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = eventData.position;
        //Debug.Log(eventData.pointerCurrentRaycast.gameObject.name);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (eventData.pointerCurrentRaycast.gameObject != null)
        {
            if (eventData.pointerCurrentRaycast.gameObject.name == "Slot_2(Clone)")
            {
                transform.SetParent(eventData.pointerCurrentRaycast.gameObject.transform);
                transform.position = eventData.pointerCurrentRaycast.gameObject.transform.position;
                if (Bag.Items[originID] == Bag.Items[eventData.pointerPressRaycast.gameObject.GetComponent<Slot>().ID])
                {
                    Bag.Items[eventData.pointerCurrentRaycast.gameObject.GetComponent<Slot>().ID] = Bag.Items[originID];
                }
                else
                {
                    Bag.Items[eventData.pointerCurrentRaycast.gameObject.GetComponent<Slot>().ID] = Bag.Items[originID];
                    Bag.Items[originID] = null;
                }
                GetComponent<CanvasGroup>().blocksRaycasts = true;
                return;
            }
            if (eventData.pointerCurrentRaycast.gameObject.name == "Image")
            {
                transform.SetParent(eventData.pointerCurrentRaycast.gameObject.transform.parent.parent);
                transform.position = eventData.pointerCurrentRaycast.gameObject.transform.parent.parent.position;

                var temp = Bag.Items[originID];
                Bag.Items[originID] = Bag.Items[eventData.pointerCurrentRaycast.gameObject.transform.GetComponentInChildren<Slot>().ID];
                Bag.Items[eventData.pointerCurrentRaycast.gameObject.GetComponentInChildren<Slot>().ID] = temp;

                eventData.pointerCurrentRaycast.gameObject.transform.parent.parent.position = originParent.position;
                eventData.pointerCurrentRaycast.gameObject.transform.parent.SetParent(originParent);

                GetComponent<CanvasGroup>().blocksRaycasts = true;
                return;
            }
        }

        if (Trash_Can.HaveCatch)
        {
            Destroy(transform);
            Bag.Items[originID] = null;
        }
        Destroy(transform);
        //    GetComponent<CanvasGroup>().blocksRaycasts = true;
        //    return;

    }
}
