using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

// INHERITANCE
public class Cylinder : Shape
{
    public Cylinder(string name, ShapeColor color) : base(name, color) { }

    // POLYMORPHISM
    public override void SetDisplayText()
    {
        displayText.text = "This is a " + materials[(int)color].name + " colored CYLINDER named " + objectName;
    }
}
