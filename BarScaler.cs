using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarScaler : MonoBehaviour
{

    // GameObject to base height of Bar Graph on
    public GameObject model;

    // GameObject representing the bar
    public GameObject bar;

    // Index representing the dimension to base the height of the bar off of
    // 0: X, 1: Y, 2: Z, 3: Radius
    public int index;


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

        // Set the height of the bar to the corresponding dimension of the GameObject
        // 0: X, 1: Y, 2: Z
        // Default scalar value for height is Y
        if (index == 0){
            barScale.y = modelScale.x;
        } else if (index ==1 ){
            barScale.y = modelScale.y;
        } else if (index == 2) {
            barScale.y = modelScale.z;
        } else{
            barScale.y = modelScale.x / 2;
        }

        // Code found at https://answers.unity.com/questions/120081/how-can-i-scale-my-object-quotupwardsquot.html
        // Makes it appear as if object is only scaling upwards
        barPosition.y = 0 + barScale.y/100;

        bar.transform.localScale = barScale;
        //bar.transform.position = barPosition;
    }
}
