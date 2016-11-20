using UnityEngine;
using System.Collections;

public class FlyingObstacleController : ObstacleController {

    /// <summary>
    /// Generate the position of flying obstacle,
    /// to the random position in range -5 until 10 of x position,
    /// and so the y position of flying obstacle.
    /// </summary>
	void Start () {
        this.startPos = transform.position;
        Vector3 pos = transform.position;
        pos.x += Random.Range(-5, 10);
        pos.y = random();
        transform.position = pos;
    }

    /// <summary>
    /// Reset the position of flying obstacle.
    /// </summary>
    public override void reset()
    {
        transform.position = startPos;
        Start();
    }

    /// <summary>
    /// Generate the random position flying obstacle when touch the destroy collider.
    /// </summary>
    public override void move()
    {
        Vector3 pos = transform.position;
        pos.x = xPos;
        pos.x += Random.Range(40, 60);
        pos.y = random();
        transform.position = pos;
    }

    /// <summary>
    /// Random method called when position of y so didn't take to close of ground obstacles.
    /// </summary>
    /// <returns>The value of random the y position.</returns>
    private float random()
    {
        float res = 0;
        if (Random.value <= 0.75)
        {
            do
            {
                res = Random.Range(4.4f, 12.4f);
            } while (res < 11.5f);
        }
        else
        {
            do
            {
                res = Random.Range(4.4f, 12.4f);
            } while (res > 8);
        }
        //Debug.Log(res);
        return res;
    }
}
