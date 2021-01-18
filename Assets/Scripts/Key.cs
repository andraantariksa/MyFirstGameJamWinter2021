using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    void OnDestroy()
    {
        if (transform.parent != null)
        {
            transform.parent.gameObject.GetComponent<PlayerControl>().ChangeIsCarrying(false);
        }    
    }
}
