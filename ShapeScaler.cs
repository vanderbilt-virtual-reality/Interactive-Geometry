using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShapeScaler : OVRGrabber
{

    // Update is called once per frame
    void Update()
    {
        base.OnUpdatedAnchors();
    }

    // Hands follow the touch anchors by calling MovePosition each frame to reach the anchor.
    // This is done instead of parenting to achieve workable physics. If you don't require physics on
    // your hands or held objects, you may wish to switch to parenting.
    protected override void OnUpdatedAnchors()
    {
        Vector3 handPos = OVRInput.GetLocalControllerPosition(m_controller);
        Quaternion handRot = OVRInput.GetLocalControllerRotation(m_controller);
        Vector3 destPos = m_parentTransform.TransformPoint(m_anchorOffsetPosition + handPos);
        Quaternion destRot = m_parentTransform.rotation * handRot * m_anchorOffsetRotation;
        GetComponent<Rigidbody>().MovePosition(destPos);
        GetComponent<Rigidbody>().MoveRotation(destRot);

        // DO THE MATH HERE
        // Calculate distance between where hand originally was and where it is now
        // That geometric distance should be the increased Y value in Scale of the object
        // (TODO): How to measure distance in 3D plane? Maybe only consider 2D change 
        float distance = destPos.magnitude - handPos.magnitude;

        if (!m_parentHeldObject)
        {
            // Original Call
            // MoveGrabbedObject(destPos, destRot);
            AdjustObjectScale(distance);
        }
        m_lastPos = transform.position;
        m_lastRot = transform.rotation;

        float prevFlex = m_prevFlex;
        // Update values from inputs
        // CHANGING FROM PrimaryHandTrigger to PrimaryIndexTrigger to distinguish between grabbing and extending
        m_prevFlex = OVRInput.Get(OVRInput.Axis1D.PrimaryIndexTrigger, m_controller);

        CheckForGrabOrRelease(prevFlex);
    }


    protected void AdjustObjectScale(float distanceChange)
    {
        if (m_grabbedObj == null)
        {
            return;
        }

        GameObject gameObject = m_grabbedObj.gameObject;

        // Found @https://www.youtube.com/watch?v=e7I315b74HY

        // Could also probably use m_parentTransform.localScale because the parent of the script shoud be the GameObject
        Vector3 scale = gameObject.transform.localScale;
        // UNCOMMENT THIS LINE TO CHANGE BASED ON HAND MOTION
        // (TODO): Right now, doesn't work continously. One click and it jumps
        // Also, current calculation of distanceChange is off. Too big
        //scale.y += distanceChange;

        // UNCOMMENT THIS LINE FOR PRESS AND HOLD TO EXTRUDE
        scale.y += Time.deltaTime;
        gameObject.transform.localScale = scale;

    }
}