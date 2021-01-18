using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatExtraOp
{
    public bool FloatEqual(float a, float b, float dp)
    {
        dp = 1.0f / (dp * 10.0f);
        return (Mathf.Abs(a - b) <= dp);
    }
}
