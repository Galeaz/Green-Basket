using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class ScreenTransition : MonoBehaviour
{
    [Header("Level Transition Settings")]
    [Tooltip("Reference to the black screen UI element.")]
    public Image blackScreen;
    [Tooltip("Transition time in seconds.")]
    public float transitionTime = 1.0f;
    [Tooltip("Duration to keep the screen black after transitioning.")]
    public float postTransitionBlackDuration = 2.0f;

    private bool isTransitioning = false;
    private static ScreenTransition instance;

    private void Start()
    {
        // Check if an instance of ScreenTransition already exists.
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            // Destroy the duplicate ScreenTransition to keep only one instance.
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject); // Make the ScreenTransition persistent between scenes.
    }

    public void LoadLevel(string levelName)
    {
        if (!isTransitioning)
        {
            StartCoroutine(TransitionToLevel(levelName));
        }
    }

    private IEnumerator TransitionToLevel(string levelName)
    {
        isTransitioning = true;
        blackScreen.color = Color.clear; // Make the black screen transparent.

        // Crossfade to black.
        yield return StartCoroutine(FadeIn());

        // Load the new level.
        SceneManager.LoadScene(levelName);

        // Continue the black screen effect while the scene is loading.
        while (!SceneManager.GetSceneByName(levelName).isLoaded)
        {
            yield return null;
        }

        // Keep the screen black for the specified duration.
        yield return new WaitForSeconds(postTransitionBlackDuration);

        // Crossfade from black.
        yield return StartCoroutine(FadeOut());

        isTransitioning = false;
    }

    private IEnumerator FadeIn()
    {
        float elapsedTime = 0;

        while (elapsedTime < transitionTime)
        {
            blackScreen.color = Color.Lerp(Color.clear, Color.black, elapsedTime / transitionTime);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        blackScreen.color = Color.black;
    }

    private IEnumerator FadeOut()
    {
        float elapsedTime = 0;

        while (elapsedTime < transitionTime)
        {
            blackScreen.color = Color.Lerp(Color.black, Color.clear, elapsedTime / transitionTime);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        blackScreen.color = Color.clear;
    }
}
