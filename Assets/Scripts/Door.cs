using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    Transform keyholeTransform;
    Keyhole keyhole;
    bool isLocked = false;
    Color doorColor;
    SpriteRenderer sprite;
    
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
            Time.timeScale = 0f;
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
