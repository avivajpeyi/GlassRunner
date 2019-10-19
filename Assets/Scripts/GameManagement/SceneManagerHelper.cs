using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
#if UNITY_EDITOR
using UnityEditor;
#endif


public class SceneManagerHelper : MonoBehaviour
{

    [SerializeField]
    string TestedLevelSceneName = "EndlessRunnerTestedSegments";
    [SerializeField]
    string MainMenuSceneName = "StartScreen";
    string ProcedurallyGeneratedSceneName = "EndlessRunnerProcedurallyGenerated";
    public GameObject LoadingCanvas;

    
    
    
    public void PrivacyPolicy()
    {
        Application.OpenURL("https://avivajpeyi.github.io/privacy_policies/glass_runner_pp.html");
    }


    public void Credits(string creditUrl)
    {
        Application.OpenURL(creditUrl);
    }

    public void Reload()
    {
        Debug.Log("Clickeed");

        string currentSceneName = SceneManager.GetActiveScene().name;
        Instantiate(LoadingCanvas);
        SceneManager.LoadScene(currentSceneName);
    }

    public void MainMenu()
    {
        Instantiate(LoadingCanvas);
        SceneManager.LoadScene(MainMenuSceneName);
    }

    public void TestedLevel()
    {
        Instantiate(LoadingCanvas);
        SceneManager.LoadScene(TestedLevelSceneName);
    }

    public void ProcedurallyGeneratedLevel()
    {
        Instantiate(LoadingCanvas);
        SceneManager.LoadScene(ProcedurallyGeneratedSceneName);
    }

    public void Quit()
    {
        #if UNITY_EDITOR
        EditorApplication.isPlaying = false;
        #else
        Application.Quit();
        #endif
    }


}
