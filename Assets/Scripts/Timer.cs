using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Timer : MonoBehaviour
{
    public static Timer instance;
    public Text timerText;
    TimeSpan timePlaying;
    bool isTimerOn;
    float timePassed;

    void Start() 
    {
        // timerText.text = "00:00.00";
        isTimerOn = false;
        BeginTimer();
    }

    public void BeginTimer()
    {
        print("YES");
        isTimerOn = true;
        timePassed = 0.0f;

        StartCoroutine(UpdateTimer());
    }

    public void EndTimer() 
    {
        isTimerOn = false;
    }

    //Update the timer 
    IEnumerator UpdateTimer()
    {
        while (isTimerOn)
        {
            timePassed += Time.deltaTime;
            timePlaying = TimeSpan.FromSeconds(timePassed);
            string timePlayingStr = timePlaying.ToString("mm':'ss'.'ff");
            timerText.text = timePlayingStr;

            yield return null;
        }
    }
}
