using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public bool isLocked = false;

    void OnTriggerEnter2D(Collider2D other)
    {
        Time.timeScale = 0f; 
    }
}
