using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Gameloader : MonoBehaviour {

    public void LoadScene(string arg)
    {
        SceneManager.LoadScene(arg);
    }

    public Scene GetCurrentScene()
    {
        return SceneManager.GetActiveScene();
    }
}
