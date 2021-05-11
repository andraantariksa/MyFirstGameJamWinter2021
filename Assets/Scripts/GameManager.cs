using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    AudioSource audioPlayer;
    public AudioClip loadLevel;
    InGameUI inGameUI;

    void Start() 
    {
        inGameUI = GameObject.Find("InGameUI").GetComponent<InGameUI>();
        audioPlayer = GetComponent<AudioSource>();
        PlayAudio(loadLevel);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            //Reload the scene
            RestartScene();
        }
    }

    public void PlayAudio(AudioClip clip)
    {
        audioPlayer.PlayOneShot(clip);
    }

    public void RestartScene()
    {
        inGameUI.DestroyNecessaryGameObject();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
