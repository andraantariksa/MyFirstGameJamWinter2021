using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InGameUI : MonoBehaviour
{
    public static bool isPaused = false;
    [SerializeField] GameObject pausePanel;
    Timer timer;

    void Start() 
    {
        timer = GameObject.Find("TimerText").GetComponent<Timer>();
        //Prevent the InGameUi to get destroyed. So we can keep the timer
        DontDestroyOnLoad(gameObject);
    }

    void Update() 
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }

    public void PauseGame()
    {
        isPaused = true;
        pausePanel.SetActive(true);
        Time.timeScale = 0.0f;
    }

    public void ResumeGame()
    {
        isPaused = false;
        pausePanel.SetActive(false);
        Time.timeScale = 1.0f;
    }
    
    public void QuitLevel()
    {
        ResumeGame();
        timer.EndTimer();
        DestroyNecessaryGameObject();
        SceneManager.LoadScene(0);
    }

    public void DestroyNecessaryGameObject()
    {
        Destroy(GameObject.Find("Main Camera"));
        Destroy(gameObject);
    }
}
