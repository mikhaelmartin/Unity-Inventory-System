using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
[RequireComponent(typeof(Rigidbody2D))]
public class Interactor : MonoBehaviour
{
    [SerializeField] KeyCode interactKey = KeyCode.E;

    IInteractable focusedInteractable;
    private void Update()
    {
        if (Input.GetKeyDown(interactKey) && focusedInteractable != null)
        {
            focusedInteractable.Act(this);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Enter");
        var interactable = other.GetComponentInParent<IInteractable>();
        if (interactable != null)
        {
            focusedInteractable = interactable;
            interactable.Focused(this);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        Debug.Log("Exit");
        var interactable = other.GetComponentInParent<IInteractable>();
        if (interactable != null)
        {
            interactable.UnFocused(this);
            focusedInteractable = null;
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log("Enter");
        if (other.gameObject.TryGetComponent<IInteractable>(out var interactable))
        {
            focusedInteractable = interactable;
            interactable.Focused(this);
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        Debug.Log("Exit");
        if (other.gameObject.TryGetComponent<IInteractable>(out var interactable))
        {
            interactable.UnFocused(this);
            focusedInteractable = null;
        }
    }
}
