using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class levelLoader : MonoBehaviour
{
    public GameObject[] levels;
    private int currentLevel;
    private HashSet<int> pastLevels = new HashSet<int>();
    public scoreManager score;
    public float timer = 15f;
    public Text[] timerTexts;
    public ParticleSystem particle;
    new public AudioSource audio;
    public AudioSource wAudio;
    private bool isRightAns = false;
    public GameObject gameover;
    
    
    // Start is called before the first frame update
    void Start()
    {
        score = FindObjectOfType<scoreManager>();
        loadRandomLevel();
        ResetTimer();
    }
    void Update() {
        if(timer > 0) {
            timer = timer - Time.deltaTime;
            if(timer < 0) {
                timer = 0;
                print("sorry times up.");
                loadRandomLevel();
            }
        }
        updateTimerTexts();
    }
    void updateTimerTexts() {
        foreach(Text timerText in timerTexts) {
            if(timerText != null) {
                timerText.text = "Timer : " + Mathf.Ceil(timer).ToString();
            }
        }
    }
    public void ResetTimer() {
        timer = 15f;
    }
    public void loadRandomLevel() {
        if(pastLevels.Count == levels.Length) {
            gameover.SetActive(true);
            print("levels have finished.");
            return;
        }
        if(currentLevel != -1) {
            levels[currentLevel].SetActive(false);
        }
        int randomIndex;
        do
        {
            randomIndex = Random.Range(0, levels.Length);
        }
        while(pastLevels.Contains(randomIndex));
        currentLevel = randomIndex;
        levels[currentLevel].SetActive(true);
        ResetTimer();
        isRightAns = false;
        pastLevels.Add(currentLevel);
    }
    public void rightAns() {
        if(!isRightAns) {
          particle.Play();
          audio.Play();
          score.updateScore(1);
          print("right answer");
          isRightAns = true;
          StartCoroutine(loadNextLevel());
        }
    }
    IEnumerator loadNextLevel() {
        yield return new WaitForSeconds(2f);
        loadRandomLevel();
    }
    public void wrongAns() {
            wAudio.Play();
            print("wrong Ans.");
    }
    
}
