using System.Diagnostics;
using System.Transactions;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class InventoryOnDrag : MonoBehaviour,IDragHandler
{ 
    RectTransform currentRect;

    void Awake(){
        currentRect = GetComponent<RectTransform>();
    }
 

    public void OnDrag(PointerEventData eventData){ 
        currentRect.anchoredPosition +=eventData.delta;
     }
 
}
