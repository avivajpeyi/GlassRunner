using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetDistanceText : MonoBehaviour
{

    PlayerScore playerScore;
    private Text text;

    // Start is called before the first frame update
    void Start()
    {
        playerScore = FindObjectOfType<PlayerScore>();
        text = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        int distance = playerScore.currentDistance;
        if (distance >= 0)
            text.text = " " + distance.ToString("000");
    }
}
