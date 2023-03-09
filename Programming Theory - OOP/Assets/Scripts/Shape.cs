using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public enum ShapeColor { Blue, Red, Orange, Green, Pink}

public class Shape : MonoBehaviour
{
    [SerializeField] protected string objectName;
    [SerializeField] protected ShapeColor color;
    [SerializeField] protected TMP_Text displayText;
    [SerializeField] protected Material[] materials;
    [SerializeField] protected float displayDanceDuration = 2f;
    protected bool isDancing = false;

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
        set 
        { 
            color = value;
            gameObject.GetComponent<Renderer>().material = materials[(int)color];
        }
    }

    public void DisplayText()
    {
        SetDisplayText();
        StartCoroutine(PerformDisplayDance());
        Debug.Log(displayText.text);
        displayText.enabled = true;
        Invoke(nameof(DisableDisplayText), displayDanceDuration);
    }

    public virtual void SetDisplayText()
    {
        displayText.text = "This is a " + gameObject.GetComponent<Renderer>().material.name + " colored shape named " + objectName;
    }

    public virtual IEnumerator PerformDisplayDance()
    {
        return null;
    }

    private void DisableDisplayText()
    { 
        displayText.enabled = false; 
    }

    private void OnMouseDown()
    {
        DisplayText();
    }

    private void OnDisable()
    {
        displayText.enabled = false;
    }
}
