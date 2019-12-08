using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PyramidVolumeLabel : MonoBehaviour
{
    public TextMeshPro mLabel;
    public GameObject mObject;
    public GameObject mObject2;
    public GameObject mObject3;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        mLabel = mLabel.GetComponent<TextMeshPro>();
        // Get height value (bar chart height)
        // length is going to be z axis
        float length = mObject.transform.localScale.y;
        // width is x axis
        float width = mObject2.transform.localScale.y;
        // height is y axis
        float height = mObject3.transform.localScale.y;
        // volume local var
        float volume = 0;
        if (length > 0.00 && width > 0.00 && height > 0.00)
        {
            volume = (length * width * height) / 3;
        }
        mLabel.text = volume.ToString("0.00");
    }
}