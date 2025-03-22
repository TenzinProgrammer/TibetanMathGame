using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class backBtn : MonoBehaviour
{
    public GameObject confirmationPanel;
    private string sceneToLoad;
    public Button yes;
    public Button no;
    public scoreManager score;
    public Add2Manage right;
    // Method to be called when the back button is clicked
    void Start() {
        score = FindObjectOfType<scoreManager>();
    }
    public void OnBackButtonClick()
    {
        // Load the specified scene
        SceneManager.LoadScene("mainmenu");
    }
    public void onBackCalledModeAdd() {
        SceneManager.LoadScene("mode");
    }
    public void onWithoutTimerAdd() {
        // Store the scene to load
        sceneToLoad = "addMenu";
        confirmationPanel.SetActive(true);
    }
    public void ConfirmBack() {
        score.ResetScore();
        SceneManager.LoadScene("addMenu");
    }
    public void ConfirmBackMul() {
        score.ResetScore();
        SceneManager.LoadScene("mode");
    }
    public void CancelBack() {
       confirmationPanel.SetActive(false);
    }
    public void ConfirmSub() {
        SceneManager.LoadScene("submenu");
    }
    public void subtractBack() {
        sceneToLoad = "submenu";
        confirmationPanel.SetActive(true);
    }
    public void RetryButton()
    {
        score.ResetScore();
        Add2Manage.rightCount = 0;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void MainMenuButton()
    {
        SceneManager.LoadScene("mode");
    }

    public void QuitButton()
    {
        Application.Quit();
    }
}
