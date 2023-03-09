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

    // POLYMORPHISM
    public override IEnumerator PerformDisplayDance()
    {
        if (!isDancing)
        {
            isDancing = true;
            float elapsed = 0f;
            Vector3 startEulerAngles = gameObject.transform.rotation.eulerAngles;

            while (elapsed < displayDanceDuration)
            {
                float t = elapsed / displayDanceDuration > 1 ? 1 : elapsed / displayDanceDuration;
                gameObject.transform.rotation = Quaternion.Euler(Vector3.Lerp(startEulerAngles, startEulerAngles + Vector3.up * 360f, t));

                elapsed += Time.deltaTime;

                yield return null;
            }

            //gameObject.transform.rotation = startingRotation;

            isDancing = false;
        }
    }
}
