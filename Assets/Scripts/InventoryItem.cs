using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InventoryItem : MonoBehaviour
{
    public Item item;

    [Header("UI")]
    public Image image;

    public TMP_Text countText;
    public int count = 0;
    private Image itemImage;

    [SerializeField] private GameObject deleteIcon;
    private bool isActiveDeleteIcon = false;

    private void Start() {

        // Activate DeleteItemButton onclick
        gameObject.GetComponent<Button>().onClick.AddListener(ActiveDeleteButton);

        //Delete Item onclick DeleteItemButton
        deleteIcon.GetComponent<Button>().onClick.AddListener(DeleteItem);
    }

    public void InitialiseItem(Item newItem) {
        itemImage = GetComponent<Image>();
        item = newItem;
        image.sprite = newItem.image;
        itemImage.sprite = newItem.image;
        RefreshCount();
    }

    public void RefreshCount() {
        countText.text = count.ToString();
        bool textActive = count > 1;
        countText.gameObject.SetActive(textActive);
    }

    public void ActiveDeleteButton() {
        isActiveDeleteIcon = !isActiveDeleteIcon;
        deleteIcon.SetActive(isActiveDeleteIcon);
    }

    public void DeleteItem() {
        InventoryItem invItem = gameObject.GetComponent<InventoryItem>();
        if(invItem != null) {
            Destroy(invItem.gameObject);
            ActiveDeleteButton();
        }
    }
}
