using UnityEngine;

public class GameLogic : MonoBehaviour
{
    public Transform leftHand;
    public Transform rightHand;
    public Transform playerHead;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float leftHeight =
        leftHand.position.y - playerHead.position.y;

        float rightHeight =
        rightHand.position.y - playerHead.position.y;

        if (leftHeight > 0.2f && rightHeight > 0.2f)
        {
        Debug.Log("Hands are raised!");
        }
    }
}
