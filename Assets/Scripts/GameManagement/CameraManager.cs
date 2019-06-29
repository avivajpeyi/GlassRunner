using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    bool twoDCameraSet;
    public GameObject threeDCamera;
    public GameObject twoDCamera;

    PlayerController playerController;




    // Start is called before the first frame update
    void Start()
    {
        playerController = FindObjectOfType<PlayerController>();
        bool threeDCameraSet = getCurrent3DCameraPreference();
        assignCameraToPlayer(threeDCameraSet);

    }

    public bool getCurrent3DCameraPreference()
    /*
    *  True if 3D camera preferred
    *  False if 2D camera preferred
    *   Default value is true
    */
    {
        if (PlayerPrefs.HasKey("cameraPreference"))
        {
            int camPref = PlayerPrefs.GetInt("cameraPreference");
            ////Debug.Log("PlayerPrefs: " + camPref.ToString() + "D cam");
            if (camPref == 3)
            { return true; }
            else
            { return false; }
        }
        else
        {
            PlayerPrefs.SetInt("cameraPreference", 3);
            PlayerPrefs.Save();
            return true;
        }
    }

    void setCameraPreference(int pref)
    {
        PlayerPrefs.SetInt("cameraPreference", pref);
        PlayerPrefs.Save();
    }

    public void threeDCameraBoolChanged(bool newThreeDCameraBoolVal)
    {
        if (newThreeDCameraBoolVal)
        {
            assignCameraToPlayer(newThreeDCameraBoolVal);
            setCameraPreference(3);
        }
        else
        {
            assignCameraToPlayer(newThreeDCameraBoolVal);
            setCameraPreference(2);
        }
    }

    void assignCameraToPlayer(bool has3DcameraBeenSet)
    {
        threeDCamera.SetActive(has3DcameraBeenSet);
        twoDCamera.SetActive(!has3DcameraBeenSet);

        if (has3DcameraBeenSet)
        {
            ////Debug.Log("Assiging 3d cam to player");
            playerController.cam = threeDCamera.GetComponent<Camera>(); 
        
            
        }
        else
        {
            ////Debug.Log("Assiging 2d cam to player");
            playerController.cam = twoDCamera.GetComponent<Camera>(); }
    }





}
