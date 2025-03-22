using UnityEngine;
using UnityEngine.UI;

public class SceneAudioSetup : MonoBehaviour
{
    [SerializeField] private Button audioButton;

    void Start()
    {
        if (audioButton != null)
        {
            SoundManager.Instance.SetAudioButton(audioButton);
            Debug.Log("Audio button assigned in UIManager.");
        }
        else
        {
            Debug.LogWarning("audioButton is not assigned in UIManager.");
        }
    }
}
