using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PyramidSurfaceAreaScript : MonoBehaviour
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
        // base = lw
        Vector3 pyramidBase = bar.transform.localScale;
        // front and back face = l * sqrt( (w/2)^2 + h^2)
        Vector3 frontBackFace = bar.transform.localScale;
        // left and right face = w * sqrt( (l/2)^2 + h^2)
        Vector3 leftRightFace = bar.transform.localScale;
        float frontBackVar = (modelScale.x / 2);
        float leftRightVar = (modelScale.z / 2);
        
        pyramidBase.y = (modelScale.z * modelScale.x);
        frontBackFace.y = modelScale.z * Mathf.Sqrt(frontBackVar * frontBackVar + (modelScale.y * modelScale.y));
        leftRightFace.y = modelScale.x * Mathf.Sqrt(leftRightVar * leftRightVar + (modelScale.y * modelScale.y));

        // sum of all faces
        barScale.y = pyramidBase.y + frontBackFace.y + leftRightFace.y;

        // Code found at https://answers.unity.com/questions/120081/how-can-i-scale-my-object-quotupwardsquot.html
        // Makes it appear as if object is only scaling upwards
        barPosition.y = 0 + barScale.y / 100;

        bar.transform.localScale = barScale;
        //bar.transform.position = barPosition;
    }
}
