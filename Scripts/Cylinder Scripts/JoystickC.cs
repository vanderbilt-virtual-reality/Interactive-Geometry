using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoystickC : MonoBehaviour
{
    // Vector2 representing status of right joystick
    // X is L-R, with range of -1.0f (fully left) to 1.0f (fully right)
    Vector2 rightThumbstick;

    // 1. This is the Shape that gets manipulated in the scene. Whenever you add this script to panel / joystick
    // / whatever, MAKE SURE YOU CLICK AND DRAB THE GAMEOBJECT INTO THIS FIELD
    public GameObject myGameObject;

    // 2. These values below should be self explanatory

    // This represents the degree of joystick movement at which shape extrusion will begin
    // In other words, this protects against slight / accidental movements of the thumb from 
    // affecting the shape.
    static readonly float THRESHOLD = 0.2f;

    // Minimum size values for the GameObject
    // This is to make sure that the shape will never be invisible
    // Also, negative values just extrude it the other way, which isn't what we want.
    static readonly float MIN_Z_VAL = 0.01f;
    static readonly float MIN_Y_VAL = 0.01f;
    static readonly float MIN_X_VAL = 0.01f;

    // Start is called before the first frame update
    void Start()
    {
        // Not needed?
    }

    // Update is called once per frame
    void Update()
    {
        // Says to do this within documentation
        // ** YOU WON"T NEED THIS if not using the joysticks ***
        OVRInput.Update();
        Vector2 curThumbstickVal = OVRInput.Get(OVRInput.Axis2D.SecondaryThumbstick);
        float LR = curThumbstickVal.x;
        float UD = curThumbstickVal.y;
        // ** ***

        // This Vector3 stores the CURRENT scalar values of the shape
        Vector3 scale = myGameObject.transform.localScale;


        // 3. Okay, so anywhere you see LR or UD compared to threshold, that is unique to just the joystick, because its checking
        // the current position of the joystick. 

        // 4. What you'll be able to use is the checking scale vs minimum
        // what is actually adjusting the scalar value is the -= Time.deltaTime or += Time.deltaTime
        // 

        // If above threshold and left, decrease Scalar.Z
        // So, this is if joystick is pushed left
        if (LR < (-1 * THRESHOLD))
        {
            // and if the scalar value is above the minimum (so it doesn't go negative)
            if (scale.z > MIN_Z_VAL)
            {
                // decrease the scalar value
                scale.z -= 4 * Time.deltaTime;
                scale.x -= 4 * Time.deltaTime;
            }
        }
        // so on
        // If above threshold and right, increase Scalar.Z
        else if (LR > THRESHOLD)
        {
            scale.z += 4 * Time.deltaTime;
            scale.x += 4 * Time.deltaTime;
        }

        // If above threshold and down, decrease Scalar.Y
        if (UD < (-1 * THRESHOLD))
        {
            if (scale.y > MIN_Y_VAL)
            {
                scale.y -= 4 * Time.deltaTime;
            }
        }
        // If above threshold and up, increase Scalar.Y
        else if (UD > THRESHOLD)
        {
            scale.y += 4 * Time.deltaTime;
        }

        // // This is a different check, but same idea
        // // if the thumbstick is pushed down and x > minimum, decrease
        // // Pushing down on left means smaller X 
        // if (OVRInput.Get(OVRInput.Button.PrimaryThumbstick))
        // {
        //     if (scale.x > MIN_X_VAL)
        //     {
        //         scale.x -= Time.deltaTime;
        //     }
        // }
        // // Pushing down on right means bigger X
        // else if (OVRInput.Get(OVRInput.Button.SecondaryThumbstick))
        // {
        //     scale.x += Time.deltaTime;
        // }

        // 5. THIS IS KEY - must reset the shape's scalar values to the new adjusted values
        // Left button down means smaller X, Right button down means bigger X
        myGameObject.transform.localScale = scale;

    }
}