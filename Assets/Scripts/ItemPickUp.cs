using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickUp : MonoBehaviour
{
    public Item item;

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Player")) {
            InventoryManager.Instance.AddItem(item);
            Destroy(gameObject);
        }
    }
}
