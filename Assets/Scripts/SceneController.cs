using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public void SceneChange(string scene)
    {
        SceneManager.LoadScene(scene);
    }
    public void Quit()
    {
        Application.Quit();
    }
}
