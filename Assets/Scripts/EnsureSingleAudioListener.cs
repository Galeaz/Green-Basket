using UnityEngine;

public class EnsureSingleAudioListener : MonoBehaviour
{
    private void Awake()
    {
        // Find all Audio Listeners in the scene.
        AudioListener[] audioListeners = FindObjectsOfType<AudioListener>();

        // If there is more than one Audio Listener, disable the extras.
        if (audioListeners.Length > 1)
        {
            for (int i = 1; i < audioListeners.Length; i++)
            {
                audioListeners[i].enabled = false;
            }
        }
    }
}
