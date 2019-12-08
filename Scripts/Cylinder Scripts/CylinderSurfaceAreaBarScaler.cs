using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CylinderSurfaceAreaBarScaler : MonoBehaviour
{
    // GameObject to base height of Bar Graph on
    public GameObject model;

    // GameObject representing the bar
    public GameObject bar;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 modelScale = model.transform.localScale;
        Vector3 barScale = bar.transform.localScale;
        Vector3 barPosition = bar.transform.position;
        // top and bottom face: 2pir^2
        Vector3 circularFace = bar.transform.localScale;
        // body wrapped around cylinder: 2pirh
        Vector3 cylindricalPlane = bar.transform.localScale;
    

        circularFace.y = 2* ((modelScale.x/2) * (modelScale.x / 2) * Mathf.PI);
        cylindricalPlane.y = 2 * (Mathf.PI * (modelScale.x / 2) * modelScale.y);

        // sum of all faces
        // reduce scaling
        barScale.y = (circularFace.y + cylindricalPlane.y);

        // Code found at https://answers.unity.com/questions/120081/how-can-i-scale-my-object-quotupwardsquot.html
        // Makes it appear as if object is only scaling upwards
        barPosition.y = 0 + (barScale.y / 100);

        bar.transform.localScale = barScale;
        //bar.transform.position = barPosition;
    }
}
