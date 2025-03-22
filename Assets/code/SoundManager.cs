using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    private bool isMuted;
    private static SoundManager instance;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private Sprite soundOnSprite;
    [SerializeField] private Sprite soundOffSprite;
    private Button audioButton;

    public static SoundManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<SoundManager>();
                if (instance == null)
                {
                    GameObject soundManager = new GameObject("SoundManager");
                    instance = soundManager.AddComponent<SoundManager>();
                    DontDestroyOnLoad(soundManager);
                }
            }
            return instance;
        }
    }

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            Debug.Log("SoundManager instance created.");
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        if (audioSource == null)
        {
            audioSource = GetComponent<AudioSource>();
            if (audioSource == null)
            {
                audioSource = gameObject.AddComponent<AudioSource>();
                Debug.Log("AudioSource component added.");
            }
        }

        LoadAudioState();
        PlayAudio();

        // Initialize the button if it is already assigned in the inspector
        if (audioButton != null)
        {
            SetAudioButton(audioButton);
        }
    }

    void OnApplicationQuit()
    {
        SaveAudioState();
    }

    public void SetAudioButton(Button button)
    {
        audioButton = button;
        audioButton.onClick.RemoveAllListeners();
        audioButton.onClick.AddListener(ToggleMute);
        UpdateButtonSprite();
        Debug.Log("Audio button set and listeners added.");
    }

    public void ToggleMute()
    {
        isMuted = !isMuted;
        audioSource.mute = isMuted;
        UpdateButtonSprite();
        SaveAudioState();
        Debug.Log("ToggleMute called. isMuted: " + isMuted);
    }

    private void PlayAudio()
    {
        if (audioSource != null)
        {
            audioSource.Play();
            audioSource.loop = true; // Loop the audio if needed
            UpdateButtonSprite();
            Debug.Log("PlayAudio called. isMuted: " + isMuted);
        }
    }

    private void UpdateButtonSprite()
    {
        if (audioButton != null)
        {
            audioButton.image.sprite = isMuted ? soundOffSprite : soundOnSprite;
            Debug.Log("UpdateButtonSprite called. isMuted: " + isMuted);
        }
    }

    private void SaveAudioState()
    {
        PlayerPrefs.SetInt("IsAudioMuted", isMuted ? 1 : 0);
        PlayerPrefs.Save();
        Debug.Log("SaveAudioState called. isMuted: " + isMuted);
    }

    private void LoadAudioState()
    {
        isMuted = PlayerPrefs.GetInt("IsAudioMuted", 0) == 1;
        if (audioSource != null)
        {
            audioSource.mute = isMuted;
        }
        Debug.Log("LoadAudioState called. isMuted: " + isMuted);
    }
}
