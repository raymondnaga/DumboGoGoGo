using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

    public PlayerController player;

    private Vector3 lastPlayerPosition;
    private float distanceToMove;

    /// <summary>
	/// Generate the first of the game view,
	/// the view is depend on the player object and the following of it's position.
	/// </summary>
	void Start () {
        player = FindObjectOfType<PlayerController>();
        lastPlayerPosition = player.transform.position;
    }

    /// <summary>
	/// Change the view to last player position.
	/// </summary>
	void Update () {
        distanceToMove = player.transform.position.x-lastPlayerPosition.x;

        transform.position = new Vector3(transform.position.x+distanceToMove,transform.position.y,transform.position.z);

        lastPlayerPosition = player.transform.position;
	}
}
