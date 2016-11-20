using UnityEngine;
using System.Collections;

public abstract class GameObjectController : MonoBehaviour {
    protected Vector3 startPos;

    /// <summary>
    /// Reset method.
    /// </summary>
    public abstract void reset();

    /// <summary>
    /// Move method.
    /// </summary>
    public abstract void move();
}
