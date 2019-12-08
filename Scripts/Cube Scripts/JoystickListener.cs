using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoystickListener : MonoBehaviour
{
    // Vector2 representing status of right joystick
    // X is L-R, with range of -1.0f (fully left) to 1.0f (fully right)
    Vector2 rightThumbstick;

    // GameObject whose scalar values to manipulate
    public GameObject myGameObject;

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
        OVRInput.Update();

        Vector2 curThumbstickVal = OVRInput.Get(OVRInput.Axis2D.SecondaryThumbstick);
        float LR = curThumbstickVal.x;
        float UD = curThumbstickVal.y;

        Vector3 scale = myGameObject.transform.localScale;

        // If above threshold and left, decrease Scalar.Z
        if (LR < (-1 * THRESHOLD))
        {
            if (scale.z > MIN_Z_VAL)
            {
               scale.z -= 4 * Time.deltaTime;
            }
        }
        // If above threshold and right, increase Scalar.Z
        else if (LR > THRESHOLD)
        {
            scale.z += 4 * Time.deltaTime;
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

        // Pushing down on left means smaller X 
        if (OVRInput.Get(OVRInput.Button.PrimaryThumbstick))
        {
            if (scale.x > MIN_X_VAL)
            {
                scale.x -= 4 * Time.deltaTime;
            }
        }
        // Pushing down on right means bigger X
        else if (OVRInput.Get(OVRInput.Button.SecondaryThumbstick))
        {
            scale.x += 4 * Time.deltaTime;
        }

        // Left button down means smaller X, Right button down means bigger X
        myGameObject.transform.localScale = scale;
       
    }
}
