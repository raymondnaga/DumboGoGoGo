using UnityEngine;
using System.Collections;

public class InGameMenu : MonoBehaviour {
    public string mainMenuLevel;

    /// <summary>
    /// Select the main menu of game.
	/// </summary>
    public void QuitToMain()
    {
        Time.timeScale = 1f;
        Application.LoadLevel(mainMenuLevel);
    }

    /// <summary>
    /// Set game to restart to the beginning of the game.
	/// </summary>
    public void RestartGame()
    {
        Time.timeScale = 1f;
        FindObjectOfType<GameManager>().Reset();
    }
}
