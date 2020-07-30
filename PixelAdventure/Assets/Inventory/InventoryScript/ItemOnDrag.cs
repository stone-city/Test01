using System.Diagnostics;
using System.Transactions;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class ItemOnDrag : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    public Transform originalParent;
    public int currentId;
    public Transform originalTransform;
    public Inventory myBag;
    public void OnBeginDrag(PointerEventData eventData)
    {
        currentId = transform.parent.GetComponent<Slot>().slotId;
        UnityEngine.Debug.Log("currentId:" + currentId);
        originalParent = transform.parent;
        UnityEngine.Debug.Log("originalParent:" + originalParent);
        transform.SetParent(transform.parent.parent.parent);
        transform.position = eventData.position;
        GetComponent<CanvasGroup>().blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData)
    { 
        transform.position = eventData.position;
        UnityEngine.Debug.Log("拖动中:" + eventData.pointerCurrentRaycast.gameObject.name);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if(eventData.pointerCurrentRaycast.gameObject==null){
            transform.SetParent(originalParent);
            transform.position = originalParent.position;
            GetComponent<CanvasGroup>().blocksRaycasts = true;
            return;
         }
        //UnityEngine.Debug.Log("当前射线接触物品:"+eventData.pointerCurrentRaycast.gameObject.name);
        if (eventData.pointerCurrentRaycast.gameObject.name == "itemImage")
        {
            transform.SetParent(eventData.pointerCurrentRaycast.gameObject.transform.parent.parent);
            transform.position = eventData.pointerCurrentRaycast.gameObject.transform.parent.position;
            exchangeBagItem(currentId,eventData.pointerCurrentRaycast.gameObject.transform.parent.parent.GetComponent<Slot>().slotId);
            eventData.pointerCurrentRaycast.gameObject.transform.parent.position = originalParent.position;
            eventData.pointerCurrentRaycast.gameObject.transform.parent.SetParent(originalParent);
        }
        else if (eventData.pointerCurrentRaycast.gameObject.name == "slot(Clone)")
        {
            transform.SetParent(eventData.pointerCurrentRaycast.gameObject.transform);
            transform.position = eventData.pointerCurrentRaycast.gameObject.transform.position;
            exchangeBagItem(currentId,eventData.pointerCurrentRaycast.gameObject.GetComponent<Slot>().slotId);
        }
        else
        {
            transform.SetParent(originalParent);
            transform.position = originalParent.position;
        }
        GetComponent<CanvasGroup>().blocksRaycasts = true;
        currentId = transform.parent.GetComponent<Slot>().slotId;
        UnityEngine.Debug.Log("当前id:" + currentId);
    }

    void exchangeBagItem(int id1,int id2){
        UnityEngine.Debug.Log("exchange中:" +id1+","+id2);
        var temp = myBag.itemList[id1];
        myBag.itemList[id1] =  myBag.itemList[id2];
        myBag.itemList[id2] =  temp; 
    }


}
