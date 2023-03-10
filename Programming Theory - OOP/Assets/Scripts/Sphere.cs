using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

// INHERITANCE
public class Sphere : Shape
{
    public Sphere(string name, ShapeColor color) : base(name, color) { }

    // POLYMORPHISM
    public override void SetDisplayText()
    {
        displayText.text = "This is a " + materials[(int)color].name + " colored SPHERE named " + objectName;
    }

    // POLYMORPHISM
    public override IEnumerator PerformDisplayDance()
    {
        if (!isDancing)
        {
            isDancing = true;
            gameObject.GetComponent<Rigidbody>().AddForce(Vector3.up * 5f, ForceMode.Impulse);
            yield return new WaitForSeconds(displayDanceDuration);
            isDancing = false;
        }
    }
}
