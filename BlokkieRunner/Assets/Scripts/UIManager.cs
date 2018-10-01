using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour {

    [SerializeField]
    private GameObject _pauseMenu, _deathScreen;
    private Animator _pauseMenuAnim;
    private bool _paused;

    private void Start()
    {
        _pauseMenuAnim = _pauseMenu.GetComponent<Animator>();
    }

    void Update () {
        if (Input.GetKeyDown("escape")) {
            if (!_paused) {
                _pauseMenuAnim.Play("Pause Menu Fade In");
                _paused = true;
            } else {
                _pauseMenuAnim.Play("Pause Menu Fade Out");
                _paused = false;
            }
        }
    }

    public bool IsPaused()
    {
        return _paused;
    }
}
