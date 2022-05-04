using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using PixelCrushers.DialogueSystem;

public class Timer : MonoBehaviour
{
    public TextMeshProUGUI timertext;
    public float timeRemaining;

    private bool timerIsRunning;
    private int errorNumber;

    private int oldVal;

    private void Start()
    {
        timerIsRunning = true;
        oldVal = errorNumber;
    }

    public void Update()
    {
        errorNumber = DialogueLua.GetVariable("Event.ErrorNumber").asInt;

        if (timerIsRunning)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
                DisplayTime(timeRemaining);
            }
            else
            {
                Debug.Log("Time has run out!");
                timeRemaining = 0;
                timerIsRunning = false;
            }
        }

        if (errorNumber > oldVal)
        {
            timeRemaining -= 10;
            Debug.Log("Timer reduced to " +  timeRemaining);
            oldVal = errorNumber;
        }
    }

    public void DisplayTime(float timeToDisplay)
    {
        timeToDisplay += 1;

        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);

        timertext.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
