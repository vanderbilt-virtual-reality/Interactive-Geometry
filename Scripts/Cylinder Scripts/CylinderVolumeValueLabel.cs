using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CylinderVolumeValueLabel : MonoBehaviour
{
    public TextMeshPro mLabel;
    // radius bar
    public GameObject mObject;
    // height bar
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
        // radius is going to be the scale of the width (x) / 2 | already calc'd thru radius bar
        float radius = mObject.transform.localScale.y;
        // height is y axis
        float height = mObject2.transform.localScale.y;
       
        // volume local var 
        // V = PI*(radius)^2*H
        float volume = 0;
        if (radius > 0.00 && height > 0.00)
        {
            volume = Mathf.PI * radius * radius * height;
        }
        mLabel.text = volume.ToString("0.00");
    }
}