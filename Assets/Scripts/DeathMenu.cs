using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DeathMenu : InGameMenu {
    public GameObject pauseButton;
    private AudioController audio;

    /// <summary>
    /// Find the sricpt of audio controller.
	/// </summary>
    void Start()
    {
        audio = FindObjectOfType<AudioController>();
        pauseButton.SetActive(false);
    }

    /// <summary>
    /// Restart the game to the beginning.
    /// </summary>
    public void RestartGame()
    {
        base.RestartGame();
        pauseButton.SetActive(true);
    }
}
