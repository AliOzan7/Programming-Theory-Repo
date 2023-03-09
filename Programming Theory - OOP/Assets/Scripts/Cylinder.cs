using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using Unity.VisualScripting;
using UnityEngine;

// INHERITANCE
public class Cylinder : Shape
{
    private float displacementForDance;
    private Vector3 startingPosition;
    public Cylinder(string name, ShapeColor color) : base(name, color) { }

    private void Start()
    {
        startingPosition = gameObject.transform.position;
        displacementForDance = 1f;
    }

    // POLYMORPHISM
    public override void SetDisplayText()
    {
        displayText.text = "This is a " + materials[(int)color].name + " colored CYLINDER named " + objectName;
    }

    // POLYMORPHISM
    public override IEnumerator PerformDisplayDance()
    {
        if (!isDancing)
        {
            isDancing = true;

            float elapsed = 0f;
            float halfDuration = displayDanceDuration / 2f;

            while (elapsed < displayDanceDuration)
            {
                float t = elapsed < halfDuration ? elapsed / halfDuration : (displayDanceDuration - elapsed) / halfDuration;
                Vector3 newPosition = startingPosition + new Vector3(0f, 0f, Mathf.Lerp(0f, displacementForDance, t));

                gameObject.transform.position = newPosition;

                elapsed += Time.deltaTime;

                yield return new WaitForEndOfFrame();
            }

            //gameObject.transform.position = startingPosition;

            isDancing = false;
        }
    }
}
