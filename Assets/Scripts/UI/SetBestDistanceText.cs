using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetBestDistanceText : MonoBehaviour
{

    PlayerScore playerScore;
    private Text text;

    private bool textSet = false; 

    // Start is called before the first frame update
    void Start()
    {
        playerScore = FindObjectOfType<PlayerScore>();
        text = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        //string gameOverStr = "Game Over!";

        if (playerScore.gameOver)
        {
            if (!textSet)
                SetGameOverScore();
            textSet = true;

        }

    }

    void SetGameOverScore()
    {
        int distance = playerScore.currentDistance;
        if (distance < 0)
            distance = 0;

        string currentScoreValStr = distance.ToString("000");
        string highScoreValStr = playerScore.farthestDistance.ToString("000");

        string currentScoreStr = "Distance Travelled: " + currentScoreValStr;
        string highScoreStr = "Furthest Travelled: " + highScoreValStr;

        text.text = currentScoreStr + "\n" + highScoreStr;
    }

}
