using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public enum ShapeColor { Blue, Red, Orange, Green}

public class Shape : MonoBehaviour
{
    [SerializeField] protected string objectName;
    [SerializeField] protected ShapeColor color;
    [SerializeField] protected TMP_Text displayText;
    [SerializeField] protected Material[] materials;

    private void Awake()
    {
        displayText.enabled = false;
        gameObject.GetComponent<Renderer>().material = materials[(int)color];
    }

    public Shape(string name, ShapeColor color)
    {
        this.objectName = name;
        this.color = color;
    }

    // ENCAPSULATION
    // A validation for the name can be applied here.
    public string Name
    {
        get { return objectName; }
        set { objectName = value; }
    }

    public ShapeColor Color
    {
        get { return color; }
        set { color = value; }
    }

    public void DisplayText()
    {
        SetDisplayText();
        Debug.Log(displayText.text);
        displayText.enabled = true;
        Invoke("DisableDisplayText", 2f);
    }

    public virtual void SetDisplayText()
    {
        displayText.text = "This is a " + materials[(int)color].name + " colored shape named " + objectName;
    }

    private void DisableDisplayText()
    { displayText.enabled = false; }

    private void OnMouseDown()
    {
        DisplayText();
    }

    private void OnDisable()
    {
        displayText.enabled = false;
    }
}
