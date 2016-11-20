using UnityEngine;
using System.Collections;
using System;

public class AudioController : GameObjectController {

    private AudioSource sound;

    /// <summary>
    /// Get the audio file to play.
	/// </summary>
    void Start () {
        sound = GetComponent<AudioSource>();
        sound.Play();
    }

    /// <summary>
    /// Reset the audio to the beginning.
	/// </summary>
    public override void reset()
    {
        sound.Play();
    }

    /// <summary>
    /// Not supported method for audio controller class.
    /// </summary>
    public override void move()
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Stop the sound of audio file.
    /// </summary>
    public void stop()
    {
        sound.Stop();
    }
}
