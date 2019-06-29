using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetViewBoolValue : MonoBehaviour
{

    CameraManager cameraManager;
    Toggle toggle;

    // Start is called before the first frame update
    void Start()
    {
        cameraManager = FindObjectOfType<CameraManager>();
        toggle = GetComponent<Toggle>();
        toggle.isOn = cameraManager.getCurrent3DCameraPreference();

        //Add listener for when the state of the Toggle changes, to take action
        toggle.onValueChanged.AddListener(delegate {
            ToggleValueChanged(toggle);
        });
    }


    public void ToggleValueChanged(Toggle change)
    {
        ////Debug.Log("Toggle turned " + toggle.isOn);
        cameraManager.threeDCameraBoolChanged(toggle.isOn);
    }


}
