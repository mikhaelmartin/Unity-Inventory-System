using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemContextMenu : MonoBehaviour
{
    [SerializeField] Button useButton;
    [SerializeField] Button dropButton;

    public Button UseButton { get => useButton; }
    public Button DropButton { get => dropButton; }
}
