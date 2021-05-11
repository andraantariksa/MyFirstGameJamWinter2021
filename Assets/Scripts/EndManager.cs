using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
public class EndManager : MonoBehaviour
{
    public Text endTime;
    Timer timer;
    
    void Start()
    {
        timer = GetComponent<Timer>();
        TimeSpan timePlaying = TimeSpan.FromSeconds(Timer.timePassed);
        timer.EndTimer();

        string timePlayingStr = timePlaying.ToString("mm':'ss'.'ff");
        
        endTime.text = timePlayingStr;
    }

    public void PlayAgain()
    {
        SceneManager.LoadScene(1);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
