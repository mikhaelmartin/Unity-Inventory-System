using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(ExampleRequireComponent))]
[AddComponentMenu(menuName:"Custom Component/Custom Script", order:10)]
public class AttributeExamples : MonoBehaviour
{
    private int hiddenInt;
    
    [Header("Int values:")]
    [SerializeField]
    private int showedInt;

    [Header("Float values:"), Range(3,15)]
    public float showedFloat;
    
    [HideInInspector] public float hiddenFloat;

    [TextArea(5,20)]
    public string text = "Attribute to make a string be edited with a height-flexible and scrollable text area.";

    [ContextMenu("Methods/Print text")]
    public void PrintText()
    {
        Debug.Log(text);
    }
    private const float PHI = 3.14f; 
    Rigidbody rb;
    private void Awake() {
        rb = GetComponent<Rigidbody>();        
    }
    
}
