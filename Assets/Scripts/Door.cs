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
    
    void Start() 
    {
        sprite = GetComponent<SpriteRenderer>();
        keyholeTransform = gameObject.transform.Find("Keyhole");
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
        UpdateDoorColor();
    }
}
