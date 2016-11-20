using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {

    public Text ScoreText;
    public Text HighScoreText;
    static private long highScore;
    private PlayerController player;

    /// <summary>
    /// Set the score to zero and the high score with the highest score at before play.
    /// </summary>
	void Start () {
        highScore=PlayerPrefs.GetInt("highscore", 0);
        HighScoreText.text = "High Score: " + highScore;
        player = FindObjectOfType<PlayerController>();
	}

    /// <summary>
    /// Always set the score always going advanced and matching with the move of character.
    /// </summary>
    void Update () {
        ScoreText.text="Score: "+(long)player.score;
        HighScoreText.text = "High Score: " + highScore;
        if (highScore < player.score)
        {
            highScore = (long)player.score;
        }
	}

    /// <summary>
    /// Set the score to the high score.
    /// </summary>
    void OnDestroy()
    {
        PlayerPrefs.SetInt("highscore", (int)highScore);
    }
}
