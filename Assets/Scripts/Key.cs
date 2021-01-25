using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    void OnDestroy()
    {
        if (transform.parent != null)
        {
            //If the key destroyed when player carry it, change the isCarrying of player to false.
            transform.parent.gameObject.GetComponent<PlayerControl>().ChangeIsCarrying(false);
        }    
    }
}
