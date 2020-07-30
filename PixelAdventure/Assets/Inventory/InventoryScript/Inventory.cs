using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
[CreateAssetMenu(fileName = "New Inventory", menuName = "Inventory/New Inventory", order = 0)]
public class Inventory : ScriptableObject {
    public List<Item> itemList = new List<Item>();
}
 
