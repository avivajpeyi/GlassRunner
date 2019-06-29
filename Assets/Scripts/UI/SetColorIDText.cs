using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetColorIDText : MonoBehaviour
{
    ColorManager colorManager;
    private Text text;

    // Start is called before the first frame update
    void Start()
    {
        colorManager = FindObjectOfType<ColorManager>();
        text = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        text.text = "ColorID: "+ colorManager.colorIdx.ToString();
    }
}
