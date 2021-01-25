using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameMainCamera : MonoBehaviour
{   
    void Start()
    {
        DontDestroyOnLoad(gameObject);
    }
}
