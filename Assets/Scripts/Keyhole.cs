using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Keyhole : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        Destroy(other.gameObject);
        Destroy(gameObject);    
    }

    void OnDestroy()
    {
        gameObject.transform.parent.gameObject.GetComponent<Door>().Unlocked();
    }
}
