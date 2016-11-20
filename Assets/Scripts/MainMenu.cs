using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour {

    public string playGameLevel;

    /// <summary>
    /// Start the game.
	///</summary>
    public void PlayGame()
    {
        Application.LoadLevel(playGameLevel);
    }

    /// <summary>
    /// Quit the game.
	/// </summary>
    public void QuitGame()
    {
        Application.Quit();
    }
}
