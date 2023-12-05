using System.Collections;
using UnityEngine;
using EasyTransition;


public class AudioIntro : MonoBehaviour
{
    public AudioClip audioClip; // Audio clip to be played
    public float audioFadeDuration = 2f; // Duration to fade out the audio
    public float durationInSeconds = 10f; // Duration of the audio clip in seconds

    public string levelToLoad; // Set this in the Inspector to specify the level to load.
    public TransitionSettings transition;
    public float loadDelay;

    void Start()
    {
        // Check if an audio clip is assigned
        if (audioClip == null)
        {
            Debug.LogError("Audio clip not assigned!");
            return;
        }

        // Play the audio clip
        StartCoroutine(PlayAudio());
    }

    IEnumerator PlayAudio()
    {
        AudioSource audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.clip = audioClip;
        audioSource.playOnAwake = false;
        audioSource.volume = 1f; // Start with full volume
        audioSource.Play();

        // Wait for the specified duration
        yield return new WaitForSeconds(durationInSeconds);

        // Start fading out the audio
        StartCoroutine(FadeOutAudio(audioSource));
    }

    IEnumerator FadeOutAudio(AudioSource audioSource)
    {
        float startVolume = audioSource.volume;
        float startTime = Time.time;

        while (Time.time < startTime + audioFadeDuration)
        {
            audioSource.volume = Mathf.Lerp(startVolume, 0f, (Time.time - startTime) / audioFadeDuration);
            yield return null;
        }

        // Ensure volume is zero
        audioSource.volume = 0f;

        // Load the next scene
        LoadNextScene();
    }

    void LoadNextScene()
    {
        TransitionManager.Instance().Transition(levelToLoad, transition, loadDelay);
    }
}
