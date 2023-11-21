using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.Interaction.Toolkit;
using TMPro;

public class HoverText : MonoBehaviour
{
    [SerializeField] private GameObject UICanvas;

    private bool showCanvas = false;

    private void Update()
    {
        if (showCanvas) {
            UICanvas.SetActive(true);
        } else {
            UICanvas.SetActive(false);
        }
    }

    public void OnHoverEntered(HoverEnterEventArgs args) {
        showCanvas = true;
    }

    public void OnHoverExited(HoverExitEventArgs args) {
        showCanvas = false;
        UICanvas.SetActive(false);
    }
}