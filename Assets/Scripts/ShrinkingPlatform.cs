using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShrinkingPlatform : MonoBehaviour
{
    FloatExtraOp fOp = new FloatExtraOp();

    public Vector3 scaleChange;
    public Vector3 scaleTarget;
    public Vector3 positionChange;
    public Vector3 positionTarget;
    public Vector2 rotationChange;

    bool scaling = true;
    bool moving = true;
    bool rotating = true;

    void FixedUpdate()
    {
        // Check if change needed
        if (scaling || moving || rotating)
        {
            //Scaling
            if (scaleChange != new Vector3(0.0f, 0.0f, 0.0f))
            {
                transform.localScale = transform.localScale + scaleChange * Time.fixedDeltaTime;

                //Change scaleChange in an axis to 0 if no change needed in that axis
                if (fOp.FloatEqual(transform.localScale.x, scaleTarget.x, 2))
                {
                    scaleChange[0] = 0.0f;
                }
                if (fOp.FloatEqual(transform.localScale.y, scaleTarget.y, 2))
                {
                    scaleChange[1] = 0.0f;
                }
            }
            else
            {
                scaling = false;
            }

            //Moving
            if (positionChange != new Vector3(0.0f, 0.0f, 0.0f))
            {
                transform.localPosition = transform.localPosition + positionChange * Time.fixedDeltaTime;

                //Change positionChange in an axis to 0 if no change needed in that axis
                if (fOp.FloatEqual(transform.localPosition.x, positionTarget.x, 2))
                {
                    positionChange[0] = 0.0f;
                }
                if (fOp.FloatEqual(transform.localPosition.y, positionTarget.y, 2))
                {
                    positionChange[1] = 0.0f;
                }
            }
            else
            {
                moving = false;
            }
        }
    }
}
