using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// INHERITANCE
public class Cube : Shape
{
    public Cube(string name, ShapeColor color) : base(name, color) { }

    // POLYMORPHISM
    public override void SetDisplayText()
    {
        displayText.text = "This is a " + materials[(int)color].name + " colored CUBE named " + objectName;
    }
}
