using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ValueLabelMonitor : MonoBehaviour
{

    public TextMeshPro mLabel;
    public GameObject mObject;

    float height = 0; 

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        mLabel = mLabel.GetComponent<TextMeshPro>();

        // Get height value
        if (mObject.transform.localScale.y > 0.00)
        {
            height = mObject.transform.localScale.y;
        }
        mLabel.text = height.ToString("0.00");
        
    }
}
