using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Chest : MonoBehaviour, IInteractable
{
    [SerializeField] SpriteRenderer spriteRenderer;
    [SerializeField] Sprite openedSprite;
    [SerializeField] Sprite closedSprite;

    bool isOpen;

    public void Act(Interactor interactor)
    {
        isOpen = !isOpen;
        spriteRenderer.sprite = isOpen ? openedSprite : closedSprite;
    }

    public void Focused(Interactor interactor)
    {
        spriteRenderer.DOColor(Color.grey, 0.5f).SetLoops(-1, LoopType.Yoyo);
    }

    public void UnFocused(Interactor interactor)
    {
        spriteRenderer.DOKill();
        spriteRenderer.color = Color.white;
    }
}
