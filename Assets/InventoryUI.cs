using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    [SerializeField] Inventory inventory;
    [SerializeField] GameObject slotPrefab;
    [SerializeField] ItemContextMenu itemContextMenu;
    [SerializeField] int numOfSlots = 5;
    List<RectTransform> slots = new List<RectTransform>();



    private void Start()
    {
        BuildSlots();
        PutItems();
        inventory.OnMemberChanged += PutItems;
    }

    private void BuildSlots()
    {
        Transform[] children = transform.GetComponentsInChildren<Transform>();
        foreach (var trans in children)
        {
            if (trans == this.transform)
                continue;
            Destroy(trans.gameObject);
        }

        slots.Clear();
        for (int i = 0; i < numOfSlots; i++)
        {
            var slot = Instantiate(original: slotPrefab, parent: this.transform);
            slots.Add(slot.GetComponent<RectTransform>());
        }
    }

    private void PutItems()
    {
        var emptySlots = numOfSlots;
        foreach (var item in inventory.Items)
        {
            if (emptySlots != 0)
            {
                // parent dan posisi
                item.gameObject.SetActive(true);
                item.transform.SetParent(GetComponentInParent<Canvas>().transform);
                item.transform.position = slots[numOfSlots - emptySlots].position;

                // daftarkan menu
                item.UiItem.AddContextMenu(itemContextMenu);
                emptySlots -= 1;
            }
            else
            {
                item.gameObject.SetActive(false);
            }


        }
    }

}
