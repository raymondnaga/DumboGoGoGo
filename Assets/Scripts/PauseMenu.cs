using UnityEngine;
using System.Collections;

public class PauseMenu : InGameMenu {

    public string mainMenuLevel;

    public GameObject pauseMenu;

    /// <summary>
    /// Pause the game show the scene of pause so set the character unable to move.
	/// </summary>
    public void PauseGame()
    {
        Time.timeScale = 0f;
        pauseMenu.SetActive(true);
    }

    /// <summary>
    /// Resume the game so set the character to can move again then remove the pause scene.
	/// </summary>
    public void ResumeGame()
    {
        Time.timeScale = 1f;
        pauseMenu.SetActive(false);
    }

    /// <summary>
    /// Restart the game to the beginning again then remove the pause scene.
	/// </summary>
    public void RestartGame()
    {
        base.RestartGame();
        pauseMenu.SetActive(false);
    }

    /// <summary>
    /// Exit to the main menu, then show the menu of the game.
	/// </summary>
    public void QuitToMain()
    {
        base.QuitToMain();
        pauseMenu.SetActive(false);
    }
}
