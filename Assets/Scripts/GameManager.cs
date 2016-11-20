using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {
    
    private GameObjectController[] controllers;
    public DeathMenu theDeathScreen;

    /// <summary>
    /// Find the script of game object controller.
	/// </summary>
    void Start()
    {
        controllers = FindObjectsOfType<GameObjectController>();
        //Debug.Log(controllers.Length);
    }

    /// <summary>
	/// This method is calling death screen from class DeathMenu,
	/// so we can't move again.
	/// </summary>
    public void RestartGame()
    {
        theDeathScreen.gameObject.SetActive(true);
        Time.timeScale = 0f;
        //StartCoroutine("RestartGameCo");
    }

    /// <summary>
	/// This method is calling death screen from class DeathMenu,
	/// so when the player died the variable set to false then the position is restart,
	/// the restart is affect to background and all other object to beginning again.
	/// </summary>
    public void Reset()
    {
        theDeathScreen.gameObject.SetActive(false);
        for(int i = 0; i < controllers.Length; i++)
        {
            controllers[i].reset();
        }
        //yield return new WaitForSeconds(0.5f);
    }
}
