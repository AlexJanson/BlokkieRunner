using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChunkSpawnerScript : MonoBehaviour {

    [SerializeField]
    private GameObject[] chunks;
    [SerializeField]
    private GameObject obj;

    private List<GameObject> _chunksList = new List<GameObject>();
    private List<GameObject> _cloudList = new List<GameObject>();

    private float timer = 0.0f;
    private bool _paused = false, _idle = true;
    private Vector3 _cloudSpawnOffset;

    public int spawnTimer = 4;
    public GameObject cloudPrefab;

    private void Start()
    {
        _cloudSpawnOffset = new Vector3(2f, Random.Range(-2f, 2f), 0f);
    }

    private void Update()
    {
        if (!_paused && !_idle) {

            timer += Time.deltaTime;
            if ((int)timer % spawnTimer == 0) {
                ChunkSpawn();
                timer++;
            }

            if (Random.Range(0, 500) < 2)
                _cloudList.Add(Instantiate(cloudPrefab,
                    this.transform.position + _cloudSpawnOffset,
                    this.transform.rotation
                ));

            if (_chunksList.Count > 5) {
                Destroy(_chunksList[0]);
                _chunksList.RemoveAt(0);
            }

            if (_cloudList.Count > 5) {
                Destroy(_cloudList[0]);
                _cloudList.RemoveAt(0);
            }
        }
    }

    private void ChunkSpawn()
    {
        _chunksList.Add(Instantiate(
            chunks[Random.Range(0, chunks.Length)],
            this.transform.position,
            this.transform.rotation
        ));
    }

    public void Pause()
    {
        _paused = true;
    }

    public void Resume()
    {
        _paused = false;
    }

    public void SetIdle(bool idle)
    {
        if (idle)
            _idle = true;
        else if (!idle) {
            _idle = false;
        }
    }

    public bool IsIdle()
    {
        return _idle;
    }

    public bool IsPaused()
    {
        return _paused;
    }
}
