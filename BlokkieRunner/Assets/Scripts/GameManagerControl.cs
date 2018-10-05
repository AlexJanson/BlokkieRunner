using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameManagerControl : MonoBehaviour {

    [SerializeField]
    private GameObject _player;
    [SerializeField]
    private UIManager _uIManager;
    [SerializeField]
    private ChunkSpawnerScript _chunkSpawner;

    private ButtonCreater buttonCreater;
    private PlayerMovement _playerMovement;
    private PlayerSkinChange _playerSkinChange;

    public GameObject ui;
    /*public List<MyButton> _skinsList = new List<MyButton>();*/
    public List<Sprite> _skinsList = new List<Sprite>();

    private bool _idle = true;

    public GameObject buttonPrefab;

    private UnityAction<Sprite> action;
    public Sprite sprite;

    private void Awake()
    {
        Time.timeScale = 1;
    }

    private void Start()
    {
        _playerMovement = _player.GetComponent<PlayerMovement>();
        _playerSkinChange = _player.GetComponent<PlayerSkinChange>();
        action = ChangePlayerSkins;
        buttonCreater = GetComponent<ButtonCreater>();
    }

    private void ChangePlayerSkins(Sprite sprite)
    {
        _playerSkinChange.ChangeSkin(sprite);
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

        if(_idle) {
            if(Input.GetButtonDown("Jump") && !_playerMovement.IsDead()) {
                SetIdle(false);
            }
        }

        if (Input.GetKeyDown(KeyCode.A)) {
            InitSkinButtons();
        }
    }

    private void InitSkinButtons()
    {
        for(int i = 0; i < _skinsList.Count; i++) {
            buttonCreater.CreateSkinButton(buttonPrefab, ui, _skinsList[i], action);
        }
    }

    private void PlayerDeath()
    {
        /*if (_gameLoader.GetCurrentScene().name == "Alex") {
            if (_playerMovement.IsDead()) {
                _gameLoader.LoadScene("Dexter");
            }
        }*/

        if (_playerMovement.IsDead()) {
            SetIdle(true);
        }
    }

    private void SetIdle(bool idle)
    {
        _idle = idle;
        if(_playerMovement.IsIdle() != idle)
            _playerMovement.SetIdle(_idle);
        if(_chunkSpawner.IsIdle() != idle)
            _chunkSpawner.SetIdle(_idle);
    }
}

[System.Serializable]
public class MyButton
{
    public Sprite sprite;

    public MyButton(Sprite sprite)
    {
        this.sprite = sprite;
    }
}