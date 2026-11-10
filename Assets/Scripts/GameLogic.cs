using UnityEngine;

public class GameLogic : MonoBehaviour
{
    public Transform leftHand;
    public Transform rightHand;
    public Transform playerHead;
    public int score = 0;

    private bool handsRaised = false;

    public float raiseThreshold = 0.2f;
    public float lowerThreshold = -0.3f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        float leftHeight =
        leftHand.position.y - playerHead.position.y;

        float rightHeight =
        rightHand.position.y - playerHead.position.y;

        if (leftHeight > raiseThreshold && rightHeight > raiseThreshold)
        {
            if(!handsRaised)
            {
                handsRaised = true;
                Debug.Log("Hands are raised");
            }
        }
        if(leftHeight < lowerThreshold && rightHeight < lowerThreshold)
        {
            if(handsRaised)
            {
                handsRaised = false;
                score++;
                Debug.Log("Full jumping jack completed");
                Debug.Log("Score: " + score);
            }
        }
    }
}
