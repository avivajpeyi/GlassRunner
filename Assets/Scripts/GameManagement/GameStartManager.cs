using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStartManager : MonoBehaviour
{

    Canvas canvas;

    void Start()
    {
        Time.timeScale = 0;
        canvas = GetComponent<Canvas>();
    }


    void Update()
    {
        if (Input.anyKey)
        {
            canvas.enabled = false;
            Time.timeScale = 1;
            Destroy(gameObject);
        }
    }

}