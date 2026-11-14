using UnityEngine;

[DefaultExecutionOrder(1000)]
public class Copy : MonoBehaviour
{
    public Transform source;

    Transform[] sourceBones;
    Transform[] copyBones;

    void Start()
    {
        sourceBones = source.GetComponentsInChildren<Transform>(true);
        copyBones = GetComponentsInChildren<Transform>(true);
    }

    void LateUpdate()
    {
        if (sourceBones.Length != copyBones.Length) return;

        transform.position = source.position;
        transform.rotation = source.rotation;

        for (int i = 1; i < copyBones.Length; i++)
        {
            copyBones[i].localPosition = sourceBones[i].localPosition;
            copyBones[i].localRotation = sourceBones[i].localRotation;
        }
    }
}
