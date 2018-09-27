using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Gameloader : MonoBehaviour {

    public void gameloader(){
        SceneManager.LoadScene("SampleScene");
    }
}
