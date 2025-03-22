using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Add2Manage : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject[] levels;
    private int currentLevel;
    private HashSet<int> pastLevels = new HashSet<int>();
    public Text[] right;
    public static int rightCount;
    public Text[] correct;
    public ParticleSystem particle;
    new public AudioSource audio;
    public AudioSource wAudio;
    private bool isRightAns = false;
    public GameObject gameover;
    
    
    // Start is called before the first frame update
    void Start()
    {
        loadRandomLevel();
    }
    void Update() {
        
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
        foreach(Text item in correct) {
            item.text = "STATUS";
        }
        isRightAns = false;
        pastLevels.Add(currentLevel);
    }
    public void rightAns() {
        if(!isRightAns) {
          particle.Play();
          audio.Play();
          rightCount++;
          foreach(Text item in right) {
            item.text = "Right : " + rightCount.ToString();
          }
          foreach(Text item in correct) {
            item.text = "Correct !";
        }
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
            foreach(Text item in correct) {
            item.text = "Wrong !";
            }
            wAudio.Play();
            print("wrong Ans.");
    }
}
