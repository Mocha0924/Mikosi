using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonController : MonoBehaviour
{
    public void SceneChange(string SceneName)
    {
        SceneManager.LoadScene(SceneName);
    }
    public void FinishGame()
    {
        Application.Quit();
    }
}
