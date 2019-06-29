using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetClickedOnText : MonoBehaviour
{

    PlayerController playerController;
    private Text text;

    // Start is called before the first frame update
    void Start()
    {
        playerController = FindObjectOfType<PlayerController>();
        text = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        text.text = "Clicked: " +playerController.SegmentClickedOn;
    }
}
