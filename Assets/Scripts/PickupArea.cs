using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupArea : MonoBehaviour
{
    GameObject item;

    void OnTriggerEnter2D(Collider2D other)
    {
        item = other.gameObject;
    }

    void OnTriggerExit2D(Collider2D other)
    {
        item = null;
    }

    public GameObject PickItem()
    {
        return item;
    }
}
