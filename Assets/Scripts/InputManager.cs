using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public static float horizontal = 0.0f;
    public static bool jump = false;
    public static bool throwKey = false;
    
    public void TouchLeft()
    {
        horizontal = -1.0f;
    }
    
    public void TouchRight()
    {
        horizontal = 1.0f;
    }

    public void TouchJump()
    {
        jump = true;
    }

    public void ClearJump()
    {
        jump = false;
    }

    public void ThrowKey()
    {
        throwKey = true;
    }

    public void ClearThrowKey()
    {
        throwKey = false;
    }

    public void ClearHorizontal()
    {
        horizontal = 0.0f;
    }
}
