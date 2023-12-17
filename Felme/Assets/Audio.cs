using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    private AudioSource musicAudioSource;
    public AudioSource[] soundEffects;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        // Get the AudioSource component attached to this GameObject
        musicAudioSource = GetComponent<AudioSource>();

        // Check if the AudioSource is present
        if (musicAudioSource == null)
        {
            Debug.LogError("AudioSource component not found on GameObject.");
        }
        else
        {
            // Subscribe to the scene change event
            SceneManager.sceneUnloaded += OnSceneUnloaded;
        }
    }

    public void PlaySFX(int sfxNumber)
    {
        soundEffects[sfxNumber].Stop();
        soundEffects[sfxNumber].Play();
    }

    void OnSceneUnloaded(Scene scene)
    {
        // Check if the current scene is the one where the audio is playing
        string[] scenes = { "Thanks", "Game", "Indo", "TakeCarePlant" };

        if (scenes.Contains(scene.name))
        {
            // Stop the audio when the scene changes
            StopMusic();
        }
    }

    void OnDestroy()
    {
        // Unsubscribe from the scene change event when the GameObject is destroyed
        SceneManager.sceneUnloaded -= OnSceneUnloaded;
    }

    public void StopMusic()
    {
        if (musicAudioSource != null && musicAudioSource.isPlaying)
        {
            musicAudioSource.Stop();
        }
    }
}