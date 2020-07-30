using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class InventoryManager : MonoBehaviour
{ 
    public GameObject emptySlot;
    public List<GameObject> slots = new List<GameObject>();
    static InventoryManager instance;

    public Inventory myBag;

    public GameObject slotGrid;
    
    //public Slot slotPrefab;
 
    public Text itemInfomation;

    void Awake() {
        if(instance!=null)
         Destroy(this);
        instance = this;  
    }

    void OnEnable() {
        RefreshItem();
        instance.itemInfomation.text = "";
    }
    
    public static void UpdateItemInfo(string itemDescription){
        instance.itemInfomation.text = itemDescription;
    }

    // public static void CreateNewItem(Item item){
    //     Slot newItem = Instantiate(instance.slotPrefab,instance.slotGrid.transform.position,Quaternion.identity);
    //     newItem.gameObject.transform.SetParent(instance.slotGrid.transform);
    //     newItem.slotItem = item;
    //     newItem.slotImage.sprite = item.itemImage;
    //     newItem.slotNum.text = item.itemHeld.ToString();
    // }

    public static void RefreshItem(){
        for (int i = 0; i <instance.slotGrid.transform.childCount ; i++)
        {
           if(instance.slotGrid.transform.childCount==0){
               break;
           } 
           Destroy(instance.slotGrid.transform.GetChild(i).gameObject);
        }      

        int slotsLength = instance.slots.Count;
        for (int j = 0; j < slotsLength; j++)
        {
               instance.slots.RemoveAt(0);
        }

        for (int i = 0; i < instance.myBag.itemList.Count; i++) 
        {
           //CreateNewItem(instance.myBag.itemList[i])
           instance.slots.Add(Instantiate(instance.emptySlot));
           instance.slots[i].transform.SetParent(instance.slotGrid.transform);
           instance.slots[i].GetComponent<Slot>().SetupSlot(instance.myBag.itemList[i]);
           instance.slots[i].GetComponent<Slot>().slotId=i;
        }
    }
}
