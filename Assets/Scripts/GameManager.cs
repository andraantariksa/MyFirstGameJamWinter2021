using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    AudioSource audioPlayer;
    public AudioClip loadLevel;

    void Start() 
    {
        audioPlayer = GetComponent<AudioSource>();
        PlayAudio(loadLevel);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            //Reload the scene
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    public void PlayAudio(AudioClip clip)
    {
        audioPlayer.PlayOneShot(clip);
    }

}
