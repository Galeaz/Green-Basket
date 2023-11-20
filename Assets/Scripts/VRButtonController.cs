using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class VRButtonController : MonoBehaviour
{
    [Header("VR Button Settings")]
    public SceneAsset levelToLoad;
    public bool useCustomImage = false;

    [Tooltip("Specify the text to display when the button is clicked.")]
    public string customButtonText = "Default Text";

    [Header("Text Settings")]
    [Tooltip("Specify the position of the text.")]
    public Vector3 textPosition = new Vector3(0f, 0f, 0f);

    [Tooltip("Specify the font size of the text.")]
    public float fontSize = 5;

    private ScreenTransition screenTransition;
    private Transform mainCameraTransform;

    private void Start()
    {
        screenTransition = FindObjectOfType<ScreenTransition>();
        mainCameraTransform = Camera.main.transform;
    }

    void LateUpdate()
    {
        transform.LookAt(transform.position + mainCameraTransform.rotation * Vector3.forward, mainCameraTransform.rotation * Vector3.up);
    }

    public void OnButtonClick()
    {
        if (screenTransition != null && levelToLoad != null)
        {
            screenTransition.customImage.enabled = true;
            screenTransition.blackScreenText.enabled = true;

            // Set the custom text
            screenTransition.blackScreenText.text = customButtonText;

            // Set the position of the text
            screenTransition.blackScreenText.rectTransform.localPosition = textPosition;

            // Set the font size of the text
            screenTransition.blackScreenText.fontSize = fontSize;

            screenTransition.rightHand.SetActive(false);
            screenTransition.leftHand.SetActive(false);

            string sceneName = levelToLoad.name;
            screenTransition.LoadLevel(sceneName);
        }
    }
}
