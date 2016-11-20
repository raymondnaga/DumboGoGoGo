using UnityEngine;
using System.Collections;

public abstract class ObstacleController : GameObjectController {

    public PlayerController player;
    protected float xPos;

    /// <summary>
    /// Set the position object with posistion of x.
    /// </summary>
    /// <param name="x">Parameter input data for change the x with float data type.</param>
    public void setX(float x)
    {
        this.xPos = x;
    }

}
