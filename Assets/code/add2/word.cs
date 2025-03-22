using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class word : MonoBehaviour
{
    public GameObject[] levels;
    public static int score;
    public Text[] status;
    public Text[] scoreTxt;
    public ParticleSystem particle;
    public AudioSource winAudio;
    public AudioSource loseAudio;
    private int currentLevel;
    private HashSet<int> pastLevels = new HashSet<int>();
    private bool isRightAns = false;
    public GameObject gameover;
    // Start is called before the first frame update
    void Start()
    {
        loadRandom();
        score = 0;
    }
    public void loadRandom() {
        if(pastLevels.Count == levels.Length) {
            gameover.SetActive(true);
            print("levels finished");
            return;
        }
        if(currentLevel != -1) {
            levels[currentLevel].SetActive(false);
        }
        int randomIndex;
        do {
            randomIndex = Random.Range(0, levels.Length);
        }
        while(pastLevels.Contains(randomIndex));
        currentLevel = randomIndex;
        levels[currentLevel].SetActive(true);
        isRightAns = false;
        pastLevels.Add(currentLevel);
    }
    public void rightAns() {
        if(!isRightAns) {
          score++;
          particle.Play();
          winAudio.Play();
          foreach(Text textComponent in scoreTxt) {
            textComponent.text = "Score : " + score.ToString();
          }
          foreach(Text item in status) {
            item.text = "Correct !";
          }
          isRightAns = true;
          StartCoroutine(loadNext());
        }
    }
    IEnumerator loadNext() {
        yield return new WaitForSeconds(2f);
        loadRandom();
    }
    public void wrongAns() {
        loseAudio.Play();
        foreach(Text item in status) {
            item.text = "Wrong !";
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
