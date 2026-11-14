using UnityEngine;
using TMPro;
using System.Timers;

public class BoxingLogic : MonoBehaviour
{
    public int score = 0;
    public float gameDuration = 30f;

    private bool gameActive = false;
    private float startTime;

    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI timerText;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        score = 0;
        startTime = Time.time;
        gameActive = true;

        scoreText.text = "Score: " + score;
    }

    // Update is called once per frame
    void Update()
    {
        if (!gameActive) return;

        if (Time.time - startTime >= gameDuration)
        {
            gameActive = false;
            timerText.text = "Time's Up!";
            return;
        }

        float timeRemaining = gameDuration - (Time.time - startTime);

        timerText.text = "Time: " + Mathf.Ceil(timeRemaining);
    }
}
