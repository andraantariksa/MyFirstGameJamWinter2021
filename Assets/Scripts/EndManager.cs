using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class EndManager : MonoBehaviour
{
    public Text endTime;
    
    void Start()
    {
        //Copy the total time passed to the EndScene timer label
        //Tben destroy the InGameUi, which contain the timer, when player reach the end screen
        GameObject inGameUI = GameObject.Find("InGameUI");
        Text timerText = inGameUI.transform.Find("Timer").Find("TimerText").gameObject.GetComponent<Text>();

        endTime.text = timerText.text;

        Destroy(inGameUI);
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
