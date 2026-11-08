using UnityEngine;
using UnityEngine.InputSystem;

public class Fist : MonoBehaviour
{
    //I needed this action to actually be able to grip when pressing the trigger through the xr toolkit
    public InputActionProperty grip;

    //A list to place each finger bone in. Tried to include the thumbs with this but it caused to much of a headache
    public Transform[] fingers;

    //Setting changeable values for the fingers to curl
    public Vector3 curlAxis = new Vector3(0, 0, 1);

    //changeable value for the angle of the curl
    public float curlangle = 70f;
    public float smooth = 15f; //This is to ensure that the fingers dont just snap open and closed

    float currentGrip; // needed because the trigger/grip presses read as between 0 and 1, so the number is needed to determine the current grip strength
    Quaternion[] openRotations;

    void Start()
    {
        openRotations = new Quaternion[fingers.Length];
        for (int i = 0; i < fingers.Length; i++)
            openRotations[i] = fingers[i].localRotation;
    }

    void LateUpdate()
    {
        float target = 0f;
        if (grip.action != null)
            target = grip.action.ReadValue<float>();

        currentGrip = Mathf.MoveTowards(currentGrip, target, smooth * Time.deltaTime);

        for (int i = 0; i < fingers.Length; i++)
            fingers[i].localRotation =
                openRotations[i] * Quaternion.AngleAxis(currentGrip * curlangle, curlAxis);
    }
}