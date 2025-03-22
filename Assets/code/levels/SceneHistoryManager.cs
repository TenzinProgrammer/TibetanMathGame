using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class SceneHistoryManager : MonoBehaviour
{
    private static SceneHistoryManager instance;
    public static SceneHistoryManager Instance => instance;

    // Use a stack to manage scene history
    private Stack<string> sceneHistory = new Stack<string>();

    private void Awake()
    {
        // Implement the singleton pattern
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // Preserve this object across scenes
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        // Push the current scene name onto the stack
        sceneHistory.Push(SceneManager.GetActiveScene().name);
    }

    // Call this method whenever a new scene is loaded
    public void OnSceneChange(string newSceneName)
    {
        sceneHistory.Push(newSceneName);
    }

    // Method to navigate back to the previous scene
    public void GoBack()
    {
        if (sceneHistory.Count > 1)
        {
            // Pop the current scene from the stack
            sceneHistory.Pop();
            
            // Load the previous scene (the one now on top of the stack)
            string previousSceneName = sceneHistory.Peek();
            SceneManager.LoadScene(previousSceneName);
        }
        else
        {
            Debug.Log("No previous scene to go back to.");
        }
    }
}
