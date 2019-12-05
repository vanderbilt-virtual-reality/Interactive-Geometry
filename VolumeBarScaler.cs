using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VolumeBarScaler : MonoBehaviour
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

        barScale.y = modelScale.x * modelScale.y * modelScale.z;
    

        // Code found at https://answers.unity.com/questions/120081/how-can-i-scale-my-object-quotupwardsquot.html
        // Makes it appear as if object is only scaling upwards
        barPosition.y = 0 + barScale.y /50.0f;

        bar.transform.localScale = barScale;
        //bar.transform.position = barPosition;
    }
}
