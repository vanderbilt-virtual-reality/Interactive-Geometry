using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SurfaceAreaBarScaler : MonoBehaviour
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
        // top and bottom face
        Vector3 topBotFace = bar.transform.localScale;
        // left and right face
        Vector3 leftRightFace = bar.transform.localScale;
        // front and back face
        Vector3 frontBackFace = bar.transform.localScale;

        topBotFace.y = (2 * modelScale.x * modelScale.z);
        leftRightFace.y = (2 * modelScale.y * modelScale.z);
        frontBackFace.y = (2 * modelScale.x * modelScale.y);
        // sum of all faces
        barScale.y = topBotFace.y + leftRightFace.y + frontBackFace.y;

        // Code found at https://answers.unity.com/questions/120081/how-can-i-scale-my-object-quotupwardsquot.html
        // Makes it appear as if object is only scaling upwards
        barPosition.y = 0 + barScale.y /50.0f;

        bar.transform.localScale = barScale;
        //bar.transform.position = barPosition;
    }
}
