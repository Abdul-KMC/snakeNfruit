using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    public int score = 0;
    public Text scoreText;
    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = "Score : " + score;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddScore(int value) {
        score += value;
        scoreText.text = "Score : " + score;
    }

    public void ResetScore() {
        score = 0;
    }
}
