using UnityEngine;
using System.Collections;
using System;

public class BackgroundController : GameObjectController
{

    public float moveSpeed;
    private Rigidbody2D rigidBody;
    private PlayerController player;

    /// <summary>
	/// Set the variable for beginning of the game start,
	/// rigidBody variable that enables physical behaviour for a GameObject,
	/// player is variable get player object that find the player script ,
	/// startPos is variable to set position of background.
	/// </summary>
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        player = GameObject.Find("player").GetComponent<PlayerController>();
        this.startPos = transform.position;
    }

    /// <summary>
	/// This method is always run once per frame for game,
	/// <example>For set the velocity of the background to 10 which mean the speed of the background is 10.</example>
	/// This means the velocity affect only with the x so only move constant to right, but when dead the velocity change to zero
	/// </summary>
    void FixedUpdate()
    {
        rigidBody.velocity = new Vector2(moveSpeed, rigidBody.velocity.y);
        if (player.isDead)
        {
            rigidBody.velocity = new Vector2(0, rigidBody.velocity.y);
        }
    }

    /// <summary>
    /// This method is generate the move of the background.
	/// </summary>
    public override void move()
    {
        //Debug.Log("move");
        float width = 29.5f;

        Vector3 pos = transform.position;
        pos.x += width * 3;

        transform.position = pos;
    }

    /// <summary>
    /// Reset the position of background controller.
	/// </summary>
    public override void reset()
    {
        transform.position = startPos;
    }
}
