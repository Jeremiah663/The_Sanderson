using UnityEngine;

public class BodyFollow : MonoBehaviour
{
    public Transform MainCam;
    public float BodyTurn = 5f;
    public float lean = 0.25f;


    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 pos = MainCam.position - transform.position;
        pos.y = 0f;

        if (pos.magnitude > lean)
        {
            transform.position += pos.normalized * (pos.magnitude - lean)
;        }

        Vector3 Forward = Vector3.ProjectOnPlane(MainCam.forward, Vector3.up);
        if (Forward.sqrMagnitude > 0.001f)
        {
            Quaternion BodyTarget = Quaternion.LookRotation(Forward.normalized, Vector3.up);
            transform.rotation = Quaternion.Slerp(transform.rotation, BodyTarget, BodyTurn * Time.deltaTime);
        }
    }
}
