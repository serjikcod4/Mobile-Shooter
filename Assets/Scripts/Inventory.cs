using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public GameObject inventorySlotPrefab; // Префаб ячейки инвентаря
    public Transform inventorySlotsParent; // Родительский объект для ячеек инвентаря

    private Item[] inventoryItems; // Массив предметов в инвентаре
    private GameObject[] inventorySlots; // Массив ячеек инвентаря

    // Вызывается при запуске сцены
    private void Start()
    {
        InitializeInventory();
    }

    // Инициализация инвентаря
    private void InitializeInventory()
    {
        // Создание массивов предметов и ячеек инвентаря
        inventoryItems = new Item[9];
        inventorySlots = new GameObject[9];

        // Создание ячеек инвентаря и привязка их к родительскому объекту
        for (int i = 0; i < inventorySlots.Length; i++)
        {
            GameObject slot = Instantiate(inventorySlotPrefab, inventorySlotsParent);
            inventorySlots[i] = slot;
        }
    }

    // Добавление предмета в инвентарь
    public void AddItem(Item item)
    {
        // Поиск первой пустой ячейки инвентаря
        int emptySlotIndex = -1;
        for (int i = 0; i < inventoryItems.Length; i++)
        {
            if (inventoryItems[i] == null)
            {
                emptySlotIndex = i;
                break;
            }
        }

        // Если найдена пустая ячейка, добавляем предмет
        if (emptySlotIndex != -1)
        {
            inventoryItems[emptySlotIndex] = item;

            // Обновляем визуальную информацию ячейки инвентаря
            UpdateInventorySlot(emptySlotIndex);
        }
    }

    // Обновление визуальной информации ячейки инвентаря
    private void UpdateInventorySlot(int slotIndex)
    {
        Item item = inventoryItems[slotIndex];
        GameObject slot = inventorySlots[slotIndex];

        Image iconImage = slot.GetComponentInChildren<Image>();
        Text quantityText = slot.GetComponentInChildren<Text>();

        if (item != null)
        {
            iconImage.sprite = item.icon; // Установка иконки предмета

            if (item.quantity > 1)
            {
                quantityText.text = item.quantity.ToString(); // Отображение количества предметов в стаке
            }
            else
            {
                quantityText.text = ""; // Если количество предметов в стаке равно 1, не отображаем текст
            }
        }
        else
        {
            iconImage.sprite = null; // Очистка иконки предмета
            quantityText.text = ""; // Очистка текста количества
        }
    }
}
