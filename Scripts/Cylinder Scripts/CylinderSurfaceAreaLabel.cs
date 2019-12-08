using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CylinderSurfaceAreaLabel : MonoBehaviour
{
    public TextMeshPro mLabel;
    // radius
    public GameObject mObject;
    // height
    public GameObject mObject2;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        mLabel = mLabel.GetComponent<TextMeshPro>();
        // Get height value (bar chart height)
        // radius is going to be artificially modified to 1/2 width based on radius bar
        float radius = mObject.transform.localScale.y;
        // height is y axis
        float height = mObject2.transform.localScale.y;
        // surface area local var
        float surfaceArea = 0;
        if (radius > 0.00 && height > 0.00)
        {
            surfaceArea = ((2 * (Mathf.PI * radius * height)) + (2 * Mathf.PI * radius * radius));
        }
        mLabel.text = surfaceArea.ToString("0.00");
    }
}