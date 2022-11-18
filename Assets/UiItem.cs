using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using DG.Tweening;

public class UiItem : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    [SerializeField] Item item;
    [SerializeField] Inventory inventory;
    [SerializeField] CanvasGroup canvasGroup;
    

    bool isDrop = false;
    bool isDrag = false;
    Vector3 originalPos;
    ItemContextMenu itemContextMenu = null;

    public bool IsDrop { get => isDrop; set => isDrop = value; }


    public void AddContextMenu(ItemContextMenu menu)
    {
        itemContextMenu = menu;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (isDrag == true)
            return;

        itemContextMenu.gameObject.SetActive(true);
        itemContextMenu.UseButton.onClick.RemoveAllListeners();
        itemContextMenu.UseButton.onClick.AddListener(item.Use);
        itemContextMenu.DropButton.onClick.AddListener(item.Drop);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        item.transform.DOScale(Vector3.one * 1.1f, 0.2f);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        item.transform.DOScale(Vector3.one, 0.2f);
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        isDrag = true;
        canvasGroup.blocksRaycasts = false;
        originalPos = item.transform.position;
        item.transform.DOScale(Vector3.one * 0.7f, 0.2f);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        Debug.Log("EndDrag");
        isDrag = false;
        canvasGroup.blocksRaycasts = true;
        item.transform.DOScale(Vector3.one, 0.2f);

        if (isDrop == false)
            item.transform.position = originalPos;

        isDrop=false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        item.transform.position = eventData.position;
    }

}
