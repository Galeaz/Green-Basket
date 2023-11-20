using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;
using TMPro;

public class ScreenTransition : MonoBehaviour
{
    [Header("Level Transition Settings")]
    [Tooltip("Reference to the screen UI element (black or custom image).")]
    public Image screenImage;
    [Tooltip("Reference to the black screen Text element.")]
    public TMP_Text blackScreenText;
    [Tooltip("Transition time in seconds.")]
    public float transitionTime = 1.0f;
    [Tooltip("Duration to keep the screen after transitioning.")]
    public float postTransitionDuration = 2.0f;
    [Tooltip("Reference to the custom image UI element.")]
    public Image customImage;

    public GameObject rightHand;
    public GameObject leftHand;

    private bool isTransitioning = false;
    private static ScreenTransition instance;
    private static VRButtonController vRButtonController;
    private static ResetPlayerPosition resetPlayerPosition;

    private void Start()
    {
        vRButtonController = FindObjectOfType<VRButtonController>();
        resetPlayerPosition = FindObjectOfType<ResetPlayerPosition>();

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
        screenImage.color = Color.clear; // Make the screen transparent.
        blackScreenText.color = Color.clear; // Make the black screen text transparent.

        // Crossfade to the screen (black or custom image).
        yield return StartCoroutine(FadeIn());

        // Load the new level.
        SceneManager.LoadScene(levelName);

        // Continue the screen effect while the scene is loading.
        while (!SceneManager.GetSceneByName(levelName).isLoaded)
        {
            yield return null;
        }

        // Keep the screen for the specified duration.
        yield return new WaitForSeconds(postTransitionDuration);

        // Crossfade from the screen.
        yield return StartCoroutine(FadeOut());

        isTransitioning = false;
    }

    private IEnumerator FadeIn()
    {
        float elapsedTime = 0;

        while (elapsedTime < transitionTime)
        {
            if (vRButtonController.useCustomImage)
            {
                screenImage.color = Color.Lerp(Color.clear, Color.white, elapsedTime / transitionTime);
            }
            else
            {
                // If useCustomImage is not true, remove the source image from customImage.
                customImage.sprite = null;
                screenImage.color = Color.Lerp(Color.clear, Color.black, elapsedTime / transitionTime);
            }

            blackScreenText.color = Color.Lerp(Color.clear, Color.white, elapsedTime / transitionTime);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        if (vRButtonController.useCustomImage)
        {
            screenImage.color = Color.white;
        }
        else
        {
            screenImage.color = Color.black;
        }

        blackScreenText.color = Color.white;
    }

    private IEnumerator FadeOut()
    {
        float elapsedTime = 0;

        while (elapsedTime < transitionTime)
        {
            if (vRButtonController.useCustomImage)
            {
                screenImage.color = Color.Lerp(Color.white, Color.clear, elapsedTime / transitionTime);
            }
            else
            {
                // If useCustomImage is not true, remove the source image from customImage.
                customImage.sprite = null;
                screenImage.color = Color.Lerp(Color.black, Color.clear, elapsedTime / transitionTime);
            }

            blackScreenText.color = Color.Lerp(Color.white, Color.clear, elapsedTime / transitionTime);

            // Enable the VR controllers when the scene starts.
            if (vRButtonController != null)
            {
                if (rightHand != null)
                    rightHand.SetActive(true);

                if (leftHand != null)
                    leftHand.SetActive(true);
            }

            resetPlayerPosition.ResetPosition();

            elapsedTime += Time.deltaTime;
            yield return null;
        }

        screenImage.color = Color.clear;
        blackScreenText.color = Color.clear;
    }
}
