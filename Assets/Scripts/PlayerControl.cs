using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public float speed;
    float moveDirection;

    public float jumpVelocity;
    public float cayoteJumpDuration;
    bool jumpPressed = false;
    float jumpTimer = 0.0f;

    public GameObject groundTriggerObject;
    GroundTrigger groundTrigger;

    public GameObject pickupAreaObject;
    public float throwingForce;
    PickupArea pickupArea;
    GameObject pickedItem;
    bool isCarrying = false;
    
    Rigidbody2D body;

    SpriteRenderer sprite;

    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        groundTrigger = groundTriggerObject.GetComponent<GroundTrigger>();
        pickupArea = pickupAreaObject.GetComponent<PickupArea>();
        sprite = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
        {
            jumpPressed = true;
        }
        else
        {
            jumpPressed = false;
        }

        moveDirection = Input.GetAxis("Horizontal");

        if (moveDirection > 0)
        {
            transform.localScale = new Vector2(1, 1);
        }
        else if (moveDirection < 0)
        {
            transform.localScale = new Vector2(-1, 1);
        }

        if (Input.GetKeyDown(KeyCode.C) || Input.GetKeyDown(KeyCode.M))
        {
            if (!isCarrying)
            {
                if (pickupArea.PickItem())
                {
                    pickedItem = pickupArea.PickItem();
                    pickedItem.transform.parent = gameObject.transform;
                    pickedItem.GetComponent<Rigidbody2D>().isKinematic = true;
                    pickedItem.transform.localPosition = new Vector3(0.0f, 0.25f, 0.0f);
                    isCarrying = true;
                }
            }
            else 
            {
                if (isCarrying)
                {
                    isCarrying = false;
                    pickedItem.transform.parent = null;
                    pickedItem.GetComponent<Rigidbody2D>().isKinematic = false;
                    pickedItem.GetComponent<Rigidbody2D>().AddForce(new Vector2(transform.localScale.x * throwingForce, 1), ForceMode2D.Impulse);
                    pickedItem = null;
                }
            }
        }
    }

    void FixedUpdate() 
    {
        if (groundTrigger.isGrounded)
        {
            jumpTimer = cayoteJumpDuration;
        }
        else
        {
            if (jumpTimer >= 0)
            {
                jumpTimer -= Time.fixedDeltaTime;
            }
        }
        if (jumpPressed)
        {
            if (jumpTimer > 0)
            {
                body.velocity = new Vector2(body.velocity.x, jumpVelocity);
            }
        }

        body.velocity = new Vector2(moveDirection * speed, body.velocity.y);
    }

    public void ChangeIsCarrying(bool value)
    {
        isCarrying = value;
    }
}
