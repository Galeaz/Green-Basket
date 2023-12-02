using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEditor;
using EasyTransition;

public class VRButtonController : MonoBehaviour
{
    [Header("VR Button Settings")]
    [Tooltip("Specify the level to load when the button is clicked.")]
    public string levelToLoad; // Set this in the Inspector to specify the level to load.

    public GameObject cashierUI;

    public TransitionSettings transition;
    public float loadDelay;

    public void OnButtonClick()
    {
        TransitionManager.Instance().Transition(levelToLoad, transition, loadDelay);
    }

    public void OnButtonClickNo()
    {
        cashierUI.SetActive(false);
    }
}
