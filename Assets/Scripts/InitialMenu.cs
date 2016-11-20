using UnityEngine;
using System.Collections;

public class InitialMenu : MonoBehaviour {

    public GameObject pauseButton;

    /// <summary>
    /// Set the menu to set scene for hint game.
	/// </summary>
	void Start () {
        Time.timeScale = 0f;
        pauseButton.SetActive(false);
    }

    /// <summary>
    /// Set the game on, so that menu goes off.
    /// </summary>
    void Update () {
        if ((Input.GetKey(KeyCode.Space) || Input.GetMouseButton(0))){            
            pauseButton.SetActive(true);
            Time.timeScale = 1f;
            gameObject.SetActive(false);
        }

    }
}
