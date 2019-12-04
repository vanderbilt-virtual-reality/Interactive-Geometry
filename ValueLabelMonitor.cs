using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ValueLabelMonitor : MonoBehaviour
{

    public TextMeshPro mLabel;
    public GameObject mObject;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        mLabel = mLabel.GetComponent<TextMeshPro>();
        
        // Get height value
        float height = mObject.transform.localScale.y;
        mLabel.text = height.ToString("0.00");
        
    }
}
