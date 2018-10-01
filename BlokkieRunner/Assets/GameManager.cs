using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerScript : MonoBehaviour {

    [SerializeField]
    private GameObject _player;

    private PlayerMovement _playerMovement;
    private Gameloader _gameLoader;

    private void Awake()
    {
        Time.timeScale = 1;
    }

    private void Start()
    {
        _playerMovement = _player.GetComponent<PlayerMovement>();
        _gameLoader = GetComponent<Gameloader>();
    }

    private void Update()
    {
        PlayerDeath();
    }

    private void PlayerDeath()
    {
        if (_gameLoader.GetCurrentScene().name == "Alex") {
            if (_playerMovement.IsDead()) {
                _gameLoader.LoadScene("Dexter");
            }
        }
    }
}