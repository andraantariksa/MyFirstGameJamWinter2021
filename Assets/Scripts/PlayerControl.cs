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
    bool isJump = false;
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

    AudioSource audioPlayer;
    public AudioClip jumpSound;
    public AudioClip pickupSound;
    public AudioClip throwSound;

    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        groundTrigger = groundTriggerObject.GetComponent<GroundTrigger>();
        pickupArea = pickupAreaObject.GetComponent<PickupArea>();
        sprite = GetComponent<SpriteRenderer>();
        audioPlayer = GetComponent<AudioSource>();
    }

    void Update()
    {
        //Detect if jump button pressed
        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
        {
            jumpPressed = true;
        }
        else
        {
            jumpPressed = false;
        }

        moveDirection = Input.GetAxis("Horizontal");

        //Facing direction
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
            //Throw item if carrying item
            if (isCarrying)
            {
                PlayAudio(throwSound);
                isCarrying = false;
                pickedItem.transform.parent = null;
                pickedItem.GetComponent<Rigidbody2D>().isKinematic = false;
                pickedItem.GetComponent<Rigidbody2D>().AddForce(new Vector2(transform.localScale.x * throwingForce, 1), ForceMode2D.Impulse);
                pickedItem = null;
            }
        }
    }

    void FixedUpdate() 
    {
        //Cayote Jump

        /*
            Check if the player is on the groud. 
            If yes, keep reseting the timer to the cayoteJumpDuration.
            If not, keep decreasing the time until it reach zero.
            When it reach zero, player can't jump.    
        */
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
            else
            {
                isJump = false;
            }
        }

        /*
            Check if the jump button pressed.
            Then check if player can jump
        */
        if (jumpPressed)
        {
            if (jumpTimer > 0)
            {
                body.velocity = new Vector2(body.velocity.x, jumpVelocity);
                if (!isJump)
                {
                    PlayAudio(jumpSound);
                    isJump = true;
                }
            }
        }

        body.velocity = new Vector2(moveDirection * speed, body.velocity.y);
    }

    public void ChangeIsCarrying(bool value)
    {
        isCarrying = value;
    }

    public void PlayAudio(AudioClip clip)
    {
        audioPlayer.PlayOneShot(clip);
    }

    //Fucntion to pick up item. Used on the PickupArea
    public void Pickup(GameObject item)
    {
        if (!isCarrying)
        {
            PlayAudio(pickupSound);
            pickedItem = item;
            pickedItem.transform.parent = gameObject.transform;
            pickedItem.GetComponent<Rigidbody2D>().isKinematic = true;
            pickedItem.transform.localPosition = new Vector3(0.0f, 0.25f, 0.0f);
            isCarrying = true;
        }
    }
}
