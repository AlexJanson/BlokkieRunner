using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerControl : MonoBehaviour {

    [SerializeField]
    private GameObject _player;
    [SerializeField]
    private UIManager _uIManager;
    [SerializeField]
    private ChunkSpawnerScript _chunkSpawner;

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

        if(_uIManager.IsPaused() && !_playerMovement.IsPaused() && !_chunkSpawner.IsPaused()) {
            _playerMovement.Pause();
            _chunkSpawner.Pause();
        }
        else if(!_uIManager.IsPaused() && _playerMovement.IsPaused() && _chunkSpawner.IsPaused()) { //this line is added for else if was an if statement and that worked OK
            _playerMovement.Resume();
            _chunkSpawner.Resume();
        }
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
