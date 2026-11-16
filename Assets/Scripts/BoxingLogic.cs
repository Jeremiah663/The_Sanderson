using UnityEngine;
using UnityEngine.XR;
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
    public XRNode controllerHand = XRNode.RightHand;

    private InputDevice controller;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        score = 0;
        gameActive = false;

        scoreText.text = "Boxing Score: " + score;
    }

    public void StartGame()
    {
        score = 0;
        startTime = Time.time;
        gameActive = true;

        scoreText.text = "Boxing Score: " + score;

        Debug.Log("Boxing Game Started!");
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

    bool ThumbButtonPressed()
    {
        if(!controller.isValid)
        {
            controller = InputDevices.GetDeviceAtXRNode(controllerHand);
        }
        bool pressed;
        if(controller.isValid && controller.TryGetFeatureValue(CommonUsages.primary2DAxisClick, out pressed))
        {
            return pressed;
        }
        return false;
    }
    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Touched by " + other.name + ", tag " + other.tag);
        if (!gameActive) return;
        if (!other.CompareTag("Hand")) return;

        score++;
        scoreText.text = "Boxing Score: " + score;
    }
}
