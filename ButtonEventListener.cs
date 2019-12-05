using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// VERY IMPORTANT - FOLLOW THESE DIRECTIONS TO ATTACH
// 1. Add this script as a component to each of 6 buttons
// 2. Drag Shape into the "shape" field (in UI)
// 3. Drag button into the "button" field
// 4. Assign the right button index for what behaviour you want - again, within Unity UI

public class ButtonEventListener : MonoBehaviour
{
    // GameObject whose scalar values to manipulate
    public GameObject shape;

    //  Button to listen to
    public Button button;

    // Index that identifies what button this should listen to
    // YOU NEED TO MANUALLY ENTER THIS AS A FIELD in UI
    // DIFFERENT INDEX FOR EACH OF 6 BUTTONS
    // 1 : X down 
    // 2 : X up
    // 3 : Y down
    // 4 : Y up
    // 5 : Z down
    // 6 : Z up
    public int buttonIndex;

    // Minimum size values for the GameObject
    // This is to make sure that the shape will never be invisible
    // Also, negative values just extrude it the other way, which isn't what we want.
    static readonly float MIN_Z_VAL = 0.01f;
    static readonly float MIN_Y_VAL = 0.01f;
    static readonly float MIN_X_VAL = 0.01f;

    // Start is called before the first frame update
    void Start()
    {
        // Not needed
    }

    // Update is called once per frame
    void Update()
    {
        if(button.Pressed == true){
            Vector3 scale = shape.transform.localScale;
            // X down
            if (index == 1) {
                if (scale.x > MIN_X_VAL)
                    {
                        scale.x -= Time.deltaTime;
                    }
            } else if (index == 2) {
                // X up
                scale.x += Time.deltaTime;
            }else if (index == 3) {
                // Y down
                if (scale.y > MIN_Y_VAL)
                    {
                        scale.y -= Time.deltaTime;
                    }
            } else if (index == 4) {
                // Y up
                scale.y += Time.deltaTime;
            } else if (index == 5) {
                // Z down
                if (scale.z> MIN_X_VAL)
                    {
                        scale.z -= Time.deltaTime;
                    }
            } else if (index == 6) {
                // Z up
                scale.z += Time.deltaTime;
            }
            shape.transform.localScale = scale;
        }
    }
}

