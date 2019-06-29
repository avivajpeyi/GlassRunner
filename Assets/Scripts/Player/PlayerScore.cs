using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScore : MonoBehaviour
{
    private Vector3 startPos;
    private Vector3 currentPos;

    public GameObject FinishLine;

    public int currentDistance  = 0;
    public int farthestDistance;

    public bool gameOver = false;

    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
        farthestDistance = GetHighScore();
        if (farthestDistance != 0)
            Instantiate(original: FinishLine, position: new Vector3(0, 2.3f, farthestDistance), rotation:Quaternion.identity);

    }


    int GetHighScore()
    {
        int highScore;
        if (PlayerPrefs.HasKey("highScore"))
        {
            highScore = PlayerPrefs.GetInt("highScore");
        }
        else
        {
            highScore = 0;
            PlayerPrefs.SetInt("highScore", highScore);
            PlayerPrefs.Save();
        }
        return highScore;
    }

    void SetHighScore(int score) 
    {
        PlayerPrefs.SetInt("highScore", score);
        PlayerPrefs.Save();
    }

    // Update is called once per frame
    void Update()
    {
        currentPos = this.transform.position;
        currentDistance = (int)(currentPos.z - startPos.z);

        if (farthestDistance <= currentDistance)
        {
            farthestDistance = currentDistance;
        }

    }

    public void GameOver()
    {
        gameOver = true;
        int priorHighScore = GetHighScore();

        if (priorHighScore < farthestDistance)
        {
            SetHighScore(farthestDistance);
        }


    }

}
