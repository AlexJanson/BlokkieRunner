using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

    [SerializeField]
    private GameObject _pauseMenu, _deathScreen, _startScreen, _fadeScreen;
    [SerializeField]
    private Text _scoreCounterText;
    private Animator _pauseMenuAnim, _deathScreenAnim, _fadeScreenAnim;
    
    private GameObject _player;
    private PlayerMovement _playerMovement;

    private bool _paused;
    private int _score;

    public delegate void ReplayDelegate();
    public event ReplayDelegate replayEvent;

    private void Start()
    {
        _pauseMenuAnim = _pauseMenu.GetComponent<Animator>();
        _deathScreenAnim = _deathScreen.GetComponent<Animator>();
        _fadeScreenAnim = _fadeScreen.GetComponent<Animator>();
        _player = GameObject.FindGameObjectWithTag("Player");
        _playerMovement = _player.GetComponent<PlayerMovement>();

        _playerMovement.deathEvent += OnPlayerDeath;
        _playerMovement.scoreChangedEvent += OnScoreChange;

        OnScoreChange(0);
    }

    public void OnScoreChange(int score)
    {
        _score = score;
        _scoreCounterText.text = "Score: " + _score;
    }

    private void Update () {
        if (Input.GetKeyDown("escape") && !_playerMovement.IsIdle()) {
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

    public void OnPlayerDeath()
    {
        _deathScreen.GetComponentInChildren<Button>().interactable = true;
        _deathScreenAnim.Play("Death Screen Fly In");
    }

    public void OnReplay()
    {
        StartCoroutine(Fade());
    }

    IEnumerator Fade()
    {
        _fadeScreen.SetActive(true);
        _fadeScreenAnim.Play("Fade Out");

        yield return new WaitForSeconds(2f);

        if (replayEvent != null)
            replayEvent();

        _deathScreenAnim.Play("New State");
        _deathScreen.GetComponentInChildren<Button>().interactable = false;
        _startScreen.SetActive(true);

        _fadeScreenAnim.Play("Fade In");
        
        yield return new WaitForSeconds(1f);

        _fadeScreen.SetActive(false);
    }

    public GameObject GetStartScreen()
    {
        return _startScreen;
    }
}
