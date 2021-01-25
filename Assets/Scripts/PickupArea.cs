using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupArea : MonoBehaviour
{
    GameObject item;
    PlayerControl parentControler;

    void Start() 
    {
        parentControler = transform.parent.gameObject.GetComponent<PlayerControl>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        parentControler.Pickup(other.gameObject);
    }

    void OnTriggerExit2D(Collider2D other)
    {
        item = null;
    }
}
