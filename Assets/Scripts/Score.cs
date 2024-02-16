using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    [SerializeField] private BallMove ballMove;
    private int score = 0;
    private Text scoreText;

    private void Start()
    {
        scoreText = GetComponent<Text>();
        UpdateScoreText();
    }

    private void Update()
    {
        if (ballMove != null && ballMove.changeHoop)
        {
            
            score++;
            UpdateScoreText();

            ballMove.changeHoop = false;
        }
    }

    private void UpdateScoreText()
    {
        // Update the text to display the current score
        scoreText.text = "Score: " + score.ToString();
    }
}
