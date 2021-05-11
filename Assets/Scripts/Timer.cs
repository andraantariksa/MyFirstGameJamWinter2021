using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Timer : MonoBehaviour
{
    Text timerText;
    TimeSpan timePlaying;
    bool isTimerOn;
    public static float timePassed;

    void Start() 
    {
        timerText = GetComponent<Text>();
        // timerText.text = "00:00.00";
        isTimerOn = false;
        BeginTimer();
    }

    public void BeginTimer()
    {
        print("YES");
        isTimerOn = true;
        StartCoroutine(UpdateTimer());
    }

    public void EndTimer() 
    {
        isTimerOn = false;
        timePassed = 0.0f;
    }

    //Update the timer 
    IEnumerator UpdateTimer()
    {
        while (isTimerOn)
        {
            timePassed += Time.deltaTime;
            timePlaying = TimeSpan.FromSeconds(timePassed);
            string timePlayingStr = timePlaying.ToString("mm':'ss'.'ff");
            if (timerText != null)
            {
                timerText.text = timePlayingStr;
            }

            yield return null;
        }
    }
}
