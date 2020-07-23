using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class ItemOnDrag : MonoBehaviour,IBeginDragHandler,IDragHandler,IEndDragHandler
{   //在这里我们要实现鼠标拖拽的接口
    public Transform originParent;  //用这个来记录拖拽物体的原始父级
    public int originID;
    public Inventory MyBag;
    public Transform DPosition;
    public LayoutElement layout;
    public void OnBeginDrag(PointerEventData eventData)   //开始拖拽
    {
        
        originParent = transform.parent;    //先保存原始父级
        originID = originParent.GetComponent<Slot>().ID;
        transform.SetParent(transform.parent.parent); 
        // 把拖拽物体的父级改为Grid(这个脚本挂载在item上，item的父级是slot,slot的父级是Grid)

        transform.position = eventData.position;  //拖拽物体的位置为鼠标位置
        GetComponent<CanvasGroup>().blocksRaycasts = false;  
        //将CanvasGroup的射线改为False。这样才能获取到拖拽物体下的物体(穿透拖拽物)，不然会被挡住
    }

    public void OnDrag(PointerEventData eventData)  //拖拽中
    {
        transform.position = eventData.position;
        //Debug.Log(eventData.pointerCurrentRaycast.gameObject.name);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if(eventData.pointerCurrentRaycast.gameObject != null){
        if(eventData.pointerCurrentRaycast.gameObject.name =="ItemImage")
        //这个名字是通过Debug得到的，就是其他物体
        {
            //这个pointerCurrentRaycast是鼠标射线
            transform.SetParent(eventData.pointerCurrentRaycast.gameObject.transform.parent.parent);
            //先将拖拽物体的父级设置为其他物体的父级的父级下
            transform.position = eventData.pointerCurrentRaycast.gameObject.transform.parent.parent.position;
            //再将拖拽物体的位置设为其他物体的父级的父级的位置
            var temp = MyBag.Items[originID];
            MyBag.Items[originID] = MyBag.Items[eventData.pointerCurrentRaycast.gameObject.GetComponentInChildren<Slot>().ID];
            MyBag.Items[eventData.pointerCurrentRaycast.gameObject.GetComponentInChildren<Slot>().ID] = temp;
            // transform.parent.GetComponent<Slot>().ID = eventData.pointerCurrentRaycast.gameObject.transform.parent.GetComponent<Slot>().ID;
            eventData.pointerCurrentRaycast.gameObject.transform.parent.parent.position = originParent.position;
            eventData.pointerCurrentRaycast.gameObject.transform.parent.SetParent(originParent);
            // eventData.pointerCurrentRaycast.gameObject.transform.parent.GetComponent<Slot>().ID = originID;


            GetComponent<CanvasGroup>().blocksRaycasts = true;
            return;
        }
        
        
        if(eventData.pointerCurrentRaycast.gameObject.name == "slot(Clone)")
        {
            transform.SetParent(eventData.pointerCurrentRaycast.gameObject.transform);
            transform.position = eventData.pointerCurrentRaycast.gameObject.transform.position;

            if(MyBag.Items[originID] == MyBag.Items[eventData.pointerCurrentRaycast.gameObject.GetComponentInParent<Slot>().ID])
            {
                MyBag.Items[eventData.pointerCurrentRaycast.gameObject.GetComponentInParent<Slot>().ID] = MyBag.Items[originID];
            }
            else
            {
                MyBag.Items[eventData.pointerCurrentRaycast.gameObject.GetComponentInParent<Slot>().ID] = MyBag.Items[originID];
                MyBag.Items[originID] = null;
            }
        
            GetComponent<CanvasGroup>().blocksRaycasts = true;
            return;
        }
                
            transform.SetParent(originParent);
            transform.position = originParent.position;
            GetComponent<CanvasGroup>().blocksRaycasts = true;
        }

       
        if (Trash_Can.HaveCatch)
        {
            Trash_Can.TrashHave = true;
            //layout.SetActive(false);
            Destroy(transform.gameObject);
            MyBag.Items[originID] = null;
            GetComponent<CanvasGroup>().blocksRaycasts = true;
            return;
        }
        transform.SetParent(originParent);
        transform.position = originParent.position;
        GetComponent<CanvasGroup>().blocksRaycasts = true;

    }

}
