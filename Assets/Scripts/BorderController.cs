using UnityEngine;
using System.Collections;
using System;

public class BorderController : GameObjectController
{
    /// <summary>
    /// This method is move the border to constantly to the right.
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
    /// Reset the position of border controller.
	/// </summary>
    public override void reset()
    {
        transform.position = startPos;
    }

    /// <summary>
    /// Generate the position of border.
	/// </summary>
    void Start()
    {
        this.startPos = transform.position;
    }
}
