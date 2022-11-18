using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Slot : MonoBehaviour, IDropHandler
{
    Canvas canvas;
    private void Awake() {
        canvas = GetComponentInParent<Canvas>();
    }
    public void OnDrop(PointerEventData eventData)
    {        
        var UiItem = eventData.pointerDrag.GetComponentInParent<UiItem>();
        var item = eventData.pointerDrag.GetComponentInParent<Item>();
        UiItem.IsDrop = true;
        item.transform.SetParent(canvas.transform);
        item.transform.position = this.transform.position;
        
    }
}
