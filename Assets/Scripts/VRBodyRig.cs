using UnityEngine;

// This script is a VR body rig that places the body under the head and turns it toward where the head is looking.
public class VRBodyRig : MonoBehaviour
{
    [System.Serializable]
    public class Map
    {
        public Transform source;   // what is tracked (camera / controller)
        public Transform target;   // the IK target
        public Vector3 positionOffset;   // source's local space
        public Vector3 rotationOffset;   // euler in the source's local space

        // Apply the source's position and rotation to the target, with offsets.
        public void Apply()
        {
            if (!source || !target) return;
            target.position = source.TransformPoint(positionOffset);
            target.rotation = source.rotation * Quaternion.Euler(rotationOffset);
        }
    }

    public Transform floorReference;
    public Map head;
    public Map leftHand;
    public Map rightHand;

    public float lean = 0.2f;

    // How far back from the head to place the body.
    public float bodyBackOffset = 0.1f; // change if need be
    // How fast to turn the body toward the head's forward direction.
    public float turnSpeed = 8f; // change if need be

    // Called after all Update functions
    void LateUpdate()
    {
        // Place the body under the head and facing the same direction.
        if (head.source)
        {
            // Stand on the floor, under the head horizontally.
            Vector3 pos = head.source.position;
            pos.y = floorReference ? floorReference.position.y : transform.position.y;
            transform.position = pos - transform.forward * bodyBackOffset;

            // Turn toward where the head faces (ignore pitch/roll).
            Vector3 fwd = Vector3.ProjectOnPlane(head.source.forward, Vector3.up);
            if (fwd.sqrMagnitude > 0.001f)
            {
                Quaternion look = Quaternion.LookRotation(fwd.normalized, Vector3.up);
                transform.rotation = Quaternion.Slerp(transform.rotation, look, turnSpeed * Time.deltaTime);
            }
        }

        // Body has moved so place the targets in world space.
        head.Apply();
        leftHand.Apply();

        rightHand.Apply();
    }
}