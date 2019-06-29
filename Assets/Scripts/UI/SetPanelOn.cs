using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetPanelOn : MonoBehaviour
{
    bool is_enambled = false;

    // Start is called before the first frame update
    void Start()
    {
        this.gameObject.SetActive(is_enambled);
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void ask_for_panel()
    {
        is_enambled = !is_enambled;
        this.gameObject.SetActive(is_enambled);
    }


    public void close_panel_if_open()
    {
        is_enambled = false;
        this.gameObject.SetActive(is_enambled);
    }

}
