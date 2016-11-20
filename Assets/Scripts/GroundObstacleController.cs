﻿using UnityEngine;
using System.Collections;
using System;

public class GroundObstacleController : ObstacleController {

	public Sprite semak;
	public Sprite batu;

    /// <summary>
    /// Generate the position of ground obstacles,
    /// to the random position in range -10 until 10 of x position,
    /// and so the y position of ground obstacles is not random because ground obstacles are not flying.
    /// And in this method we have random ground obstacles.
    /// <example>The random will choose the stone or bushes, so didn't respawn both.</example>
    /// </summary>
	void Start () {
		this.startPos = transform.position;
		Vector3 pos = transform.position;
		pos.x += UnityEngine.Random.Range(-10, 10);
		transform.position = pos;
		if (UnityEngine.Random.value >= 0.5)
		{
			changeToBatu();
		}
		else
		{
			changeToSemak();
		}
	}

    /// <summary>
    /// Reset the position of ground obstacles.
    /// </summary>
	public override void reset()
	{
		transform.position = startPos;
		Start();
	}

    /// <summary>
    /// Generate the random position ground obstacles when touch the destroy collider.
    /// </summary>
	public override void move()
	{
		Vector3 pos = transform.position;
		pos.x = xPos;
		pos.x += UnityEngine.Random.Range(30, 50);
		transform.position = pos;
		if (UnityEngine.Random.value >= 0.5)
		{
			changeToBatu();
		}
		else
		{
			changeToSemak();
		}
	}

    /// <summary>
    /// Get the script of bushes then generate the x position and same with script of box collider.
    /// </summary>
	void changeToSemak()
	{
		GetComponent<SpriteRenderer>().sprite = semak;
		transform.localScale = new Vector3(1, 1, 1);
		transform.position = new Vector3(transform.position.x, 2.7f, transform.position.z);
		GetComponent<BoxCollider2D>().size = new Vector2(3.07f, 3.11f);
	}

    /// <summary>
    /// Get the script of stone then generate the x position and same with script of box collider.
    /// </summary>
	void changeToBatu()
	{
		GetComponent<SpriteRenderer>().sprite = batu;
		transform.localScale = new Vector3(0.8f, 0.8f, 0.8f);
		transform.position = new Vector3(transform.position.x, 2.3f, transform.position.z);
		GetComponent<BoxCollider2D>().size = new Vector2(6, 3);
	}
}