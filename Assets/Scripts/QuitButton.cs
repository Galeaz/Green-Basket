using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitButton : MonoBehaviour
{
    public void OnExitButtonClick()
    {
        // This method will be called when the exit button is clicked
        Application.Quit();
    }
}
