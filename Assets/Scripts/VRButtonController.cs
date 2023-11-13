using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEditor;

public class VRButtonController : MonoBehaviour
{
    [Header("VR Button Settings")]
    [Tooltip("Specify the level to load when the button is clicked.")]
    public SceneAsset levelToLoad; // Set this in the Inspector to specify the level to load.

    public GameObject rightHand;
    public GameObject leftHand;

    private ScreenTransition screenTransition;
    private Transform mainCameraTransform;

    private void Start()
    {
        // Find the ScreenTransition component in the scene and get the main camera's transform.
        screenTransition = FindObjectOfType<ScreenTransition>();
        mainCameraTransform = Camera.main.transform;
    }

    void LateUpdate()
    {
        // Make the button always face the main camera.
        transform.LookAt(transform.position + mainCameraTransform.rotation * Vector3.forward, mainCameraTransform.rotation * Vector3.up);
    }

    public void OnButtonClick()
    {
        // Call LoadLevel with the desired scene when the button is clicked.
        if (screenTransition != null && levelToLoad != null)
        {
            // Show a black screen and load the specified scene.
            screenTransition.blackScreen.enabled = true;
            screenTransition.blackScreenText.enabled = true;
            rightHand.SetActive(false);
            leftHand.SetActive(false);
            string sceneName = levelToLoad.name;
            screenTransition.LoadLevel(sceneName);
        }
    }
}
