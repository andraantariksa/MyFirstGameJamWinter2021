using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour
{
    Transform keyholeTransform;
    Keyhole keyhole;
    bool isLocked = false;
    Color doorColor;
    SpriteRenderer sprite;

    public int levelIndex;

    AudioSource audioPlayer;
    public AudioClip unlockedSound;

    InGameUI inGameUI;
    
    void Start() 
    {
        inGameUI = GameObject.Find("InGameUI").GetComponent<InGameUI>();

        sprite = GetComponent<SpriteRenderer>();
        keyholeTransform = gameObject.transform.Find("Keyhole");
        audioPlayer = GetComponent<AudioSource>();

        //Check if the Door is locked or not
        if (keyholeTransform == null)
        {
            isLocked = false;
        }
        else
        {
            keyhole = keyholeTransform.gameObject.GetComponent<Keyhole>();
            isLocked = true;
        }
        UpdateDoorColor();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (!isLocked)
        {
            //Move to next scene
            inGameUI.DestroyNecessaryGameObject();
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); 
        } 
    }

    void UpdateDoorColor()
    {
        if (isLocked)
        {
            ColorUtility.TryParseHtmlString("#a63d40", out doorColor);
            sprite.color = doorColor;
        }
        else
        {
            ColorUtility.TryParseHtmlString("#8cb9db", out doorColor);
            sprite.color = doorColor;
        }
    }

    public void Unlocked()
    {
        isLocked = false;
        PlayAudio(unlockedSound);
        UpdateDoorColor();
    }

    public void PlayAudio(AudioClip clip)
    {
        audioPlayer.PlayOneShot(clip);
    }
}
