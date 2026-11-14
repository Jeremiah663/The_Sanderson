using UnityEngine;
using TMPro;
using System.Timers;

public class GameLogic : MonoBehaviour
{
    private static Timer timer;
    public Transform leftHand;
    public Transform rightHand;
    public Transform playerHead;
    public int score = 0;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI timerText;

    private bool handsRaised = false;
    private bool gameActive = true;

    public float raiseThreshold = 0.2f;
    public float lowerThreshold = -0.3f;

    public float gameDuration = 30f;
    private float startTime;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        score = 0;
        gameActive = false;
        setScoreText();
        timerText.text = "Press Start";
    }

    public void StartGame()
    {
        score = 0;
        handsRaised = false;

        startTime = Time.time;
        gameActive = true;

        setScoreText();

        timerText.text = "Time: " + gameDuration.ToString();
        Debug.Log("Game Started!");
    }

    // Update is called once per frame
    void Update()
    {
        if(!gameActive) return;
        if (Time.time - startTime >= gameDuration)
        {
            gameActive = false;
            timerText.text = "Time's Up!";
            Debug.Log("Time's up!");
            Debug.Log("Total: "+score);
            return;
        }

        float timeRemaining = gameDuration - (Time.time - startTime);
        timerText.text = "Time: " + Mathf.Ceil(timeRemaining).ToString();  

        float leftHeight = leftHand.position.y - playerHead.position.y;

        float rightHeight = rightHand.position.y - playerHead.position.y;

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
                setScoreText();
            }
        }
    }
    void setScoreText()
    {
        scoreText.text = "Score: " + score.ToString();
    }
}
