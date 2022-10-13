using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour {

    public enum scenes
    {
        Start,
        Level1,
        Level2,
        Level3,
        LoseGame
    };

    private void Start()
    {
    }

    public void LoadNextScene()
    {
        Scene scene = SceneManager.GetActiveScene();
        int nextScene = scene.buildIndex + 1;
        if (nextScene >= SceneManager.sceneCountInBuildSettings)
            nextScene = 0;
        SceneManager.LoadScene(nextScene);
        
    }
    
    public void LoadSceneByName(scenes name)
    {
        SceneManager.LoadScene((int)name);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
