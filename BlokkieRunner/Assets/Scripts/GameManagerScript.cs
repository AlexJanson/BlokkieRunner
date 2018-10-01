using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    [SerializeField]
    private GameObject _player;

    private PlayerMovement _playerMovement;

    private void Start()
    {
        _playerMovement = _player.GetComponent<PlayerMovement>();
    }

    private void Update()
    {
        if(_playerMovement.IsDead()) {
            Time.timeScale = 0;
        }
    }
}
