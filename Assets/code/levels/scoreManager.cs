using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scoreManager : MonoBehaviour
{
    public static int score;
    // Start is called before the first frame update
    void Start()
    {
        ResetScore();
    }
    public void updateScore(int point) {
        scoreManager.score += point;
    }
    public void ResetScore()
    {
        score = 0;
    }
}
