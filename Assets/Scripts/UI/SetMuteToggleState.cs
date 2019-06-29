using UnityEngine;
using UnityEngine.UI;

public class SetMuteToggleState : MonoBehaviour
{

    Toggle muteToggle;
    MusicAssigner musicAssigner;

    // Start is called before the first frame update
    void Start()
    {
        muteToggle = GetComponent<Toggle>();
        musicAssigner = FindObjectOfType<MusicAssigner>();

        AudioListener.pause = musicAssigner.isMuted;
        //Add listener for when the state of the Toggle changes, to take action
        muteToggle.onValueChanged.AddListener(delegate {
            MuteToggleValueChanged(muteToggle);
        });
    }


    void MuteToggleValueChanged(Toggle change)
    {
        Debug.Log("Setting mute to : " + musicAssigner.isMuted);
        musicAssigner.isMuted = !musicAssigner.isMuted;
        AudioListener.pause = musicAssigner.isMuted;
    }

}


