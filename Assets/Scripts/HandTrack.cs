using UnityEngine;

public class HandTrack : MonoBehaviour
{
    public Transform leftHand;
    public Transform rightHand;

    public Transform leftHandTarget;
    public Transform rightHandTarget;

    void LateUpdate()
    {
        if (leftHand != null && leftHandTarget != null)
        {
            leftHandTarget.position = leftHand.position;
            leftHandTarget.rotation = leftHand.rotation;
        }

        if (rightHand != null && rightHandTarget != null)
        {
            rightHandTarget.position = rightHand.position;
            rightHandTarget.rotation = rightHand.rotation;
        }
    }
}
