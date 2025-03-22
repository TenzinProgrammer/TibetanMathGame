using UnityEngine;
using UnityEngine.SceneManagement;

public class navigate : MonoBehaviour
{
    public GameObject dialog;
    public string downloadURL = "https://apps.apple.com/in/app/TibetanMathQuiz/id6532590710";

    public void load()
    {
        SceneManager.LoadScene("mode");
    }

    public void loadmode()
    {
        SceneManager.LoadScene("addMenu");
    }

    public void loadSub()
    {
        SceneManager.LoadScene("subtraction");
    }

    public void backcategory()
    {
        SceneManager.LoadScene("mainMenu");
    }

    public void loadmodeScene()
    {
        SceneManager.LoadScene("mode");
    }

    public void loadAddwithTimer()
    {
        SceneManager.LoadScene("addition");
    }

    public void loadAddwithoutTimer()
    {
        SceneManager.LoadScene("add2");
    }

    public void wordProb()
    {
        SceneManager.LoadScene("wordAdd");
    }

    public void divide()
    {
        SceneManager.LoadScene("division");
    }

    public void multiply()
    {
        SceneManager.LoadScene("multiplication");
    }

    public void loadsubwithtimer()
    {
        SceneManager.LoadScene("subtraction");
    }

    public void loadsubwithouttimer()
    {
        SceneManager.LoadScene("subtraction 1");
    }

    public void loadsubmenu()
    {
        SceneManager.LoadScene("submenu");
    }

    public void shareApp()
    {
        new NativeShare().SetTitle("Tibetan Math Game App")
                         .SetText("Download this amazing app: " + downloadURL)
                         .Share();
    }

    public void Rate()
    {
        Application.OpenURL("https://apps.apple.com/in/app/TibetanMathQuiz/id6532590710");
    }

    public void exitApp()
    {
        dialog.SetActive(true);
    }

    public void ConfirmQuit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#elif UNITY_ANDROID || UNITY_IOS
        Application.Quit();
#else
        Application.Quit();
#endif
    }

    public void CancelQuit()
    {
        dialog.SetActive(false);
    }
}
