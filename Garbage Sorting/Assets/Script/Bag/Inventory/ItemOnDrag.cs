using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class ItemOnDrag : MonoBehaviour,IBeginDragHandler,IDragHandler,IEndDragHandler
{   //在这里我们要实现鼠标拖拽的接口
    public Transform originParent;  //用这个来记录拖拽物体的原始父级
    public void OnBeginDrag(PointerEventData eventData)   //开始拖拽
    {
        originParent = transform.parent;    //先保存原始父级
        transform.SetParent(transform.parent.parent); 
        // 把拖拽物体的父级改为Grid(这个脚本挂载在item上，item的父级是slot,slot的父级是Grid)

        transform.position = eventData.position;  //拖拽物体的位置为鼠标位置
        GetComponent<CanvasGroup>().blocksRaycasts = false;  
        //将CanvasGroup的射线改为False。这样才能获取到拖拽物体下的物体(穿透拖拽物)，不然会被挡住
    }

    public void OnDrag(PointerEventData eventData)  //拖拽中
    {
        transform.position = eventData.position;
        // Debug.Log(eventData.pointerCurrentRaycast.gameObject.name);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if(eventData.pointerCurrentRaycast.gameObject.name =="ItemImage")
        //这个名字是通过Debug得到的，就是其他物体
        {
            //这个pointerCurrentRaycast是鼠标射线
            transform.SetParent(eventData.pointerCurrentRaycast.gameObject.transform.parent.parent);
            //先将拖拽物体的父级设置为其他物体的父级的父级下
            transform.position = eventData.pointerCurrentRaycast.gameObject.transform.parent.parent.position;
            //再将拖拽物体的位置设为其他物体的父级的父级的位置上

            eventData.pointerCurrentRaycast.gameObject.transform.parent.parent.position = originParent.position;
            eventData.pointerCurrentRaycast.gameObject.transform.parent.SetParent(originParent);
            GetComponent<CanvasGroup>().blocksRaycasts = true;
            return;
        }
        transform.SetParent(eventData.pointerCurrentRaycast.gameObject.transform);
        transform.position = eventData.pointerCurrentRaycast.gameObject.transform.position;
        GetComponent<CanvasGroup>().blocksRaycasts = true;
    }

}
