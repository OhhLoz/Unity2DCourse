using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void loadNextScene()
    {
        int currSceneIndex = SceneManager.GetActiveScene().buildIndex;
        //SceneManager.SetActiveScene(SceneManager.GetSceneAt(currSceneIndex + 1));
        SceneManager.LoadScene(currSceneIndex + 1);
    }

    public void loadStartScene()
    {
        SceneManager.LoadScene(0);
        FindObjectOfType<GameStatusScript>().resetGame();
    }

    public void quitGame()
    {
        Application.Quit();
    }
}
