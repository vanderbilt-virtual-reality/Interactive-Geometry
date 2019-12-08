using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CylinderVolumeBarScaler : MonoBehaviour
{
    // GameObject to base height of Bar Graph on
    public GameObject model;

    // GameObject representing the bar
    public GameObject bar;

    // Start is called before the first frame update
    void Start()
    {
        // Not needed
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 modelScale = model.transform.localScale;
        Vector3 barScale = bar.transform.localScale;
        Vector3 barPosition = bar.transform.position;
        // base 
        Vector3 circularBase = bar.transform.position;
        // height
        Vector3 height = bar.transform.position;
 
        // Essentially area of a circle (PIR^2)
        circularBase.y = ((modelScale.x / 2) * (modelScale.x / 2) * Mathf.PI);
        // height
        height.y = modelScale.y;

        if ((modelScale.x / 2) == 0 || height.y == 0)
        {
            barScale.y = 0;
        }
        else
        {
            barScale.y = circularBase.y * height.y;
        }
    
            // Code found at https://answers.unity.com/questions/120081/how-can-i-scale-my-object-quotupwardsquot.html
            // Makes it appear as if object is only scaling upwards
            barPosition.y = 0 + (barScale.y / 100);
        
        bar.transform.localScale = barScale;
        //bar.transform.position = barPosition;
    }
}
