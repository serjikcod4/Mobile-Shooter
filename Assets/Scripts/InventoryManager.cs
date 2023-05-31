using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager Instance;

    public InventorySlot[] inventorySlots;
    public GameObject inventoryItemPrefab;
    private int maxStackedItems = 200;

    private void Start() {

        if(Instance != null) {
            Destroy(gameObject);
            return;
        }

        Instance = this;
    }
    public bool AddItem(Item item) {

        //Check if any slot has the same item with count lower than max
        for(int i = 0; i < inventorySlots.Length; i++) {
            InventorySlot slot = inventorySlots[i];
            InventoryItem itemInSlot = slot.GetComponentInChildren<InventoryItem>();
            if(itemInSlot != null &&
               itemInSlot.item.id == item.id && 
               itemInSlot.count < maxStackedItems && 
               itemInSlot.item.stackable == true) {

               itemInSlot.count += item.value;
               itemInSlot.RefreshCount();
               return true;
            }
        }

        //Find empty slot
        for(int i = 0; i < inventorySlots.Length; i++) {
            InventorySlot slot = inventorySlots[i];
            InventoryItem itemInSlot = slot.GetComponentInChildren<InventoryItem>();
            if(itemInSlot == null) {
                InventoryItem newItem = SpawnNewItem(item, slot);
                newItem.count += item.value;
                newItem.RefreshCount();
                return true;
            }
        }
        return false;
    }

    InventoryItem SpawnNewItem(Item item, InventorySlot slot) {
        GameObject newItemGO = Instantiate(inventoryItemPrefab, slot.transform);
        InventoryItem inventoryItem = newItemGO.GetComponent<InventoryItem>();
        inventoryItem.InitialiseItem(item);

        return inventoryItem;
    }
}
