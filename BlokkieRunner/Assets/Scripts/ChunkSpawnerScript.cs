using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChunkSpawnerScript : MonoBehaviour {

    [SerializeField]
    private GameObject[] chunks;
    [SerializeField]
    private GameObject obj;
    [SerializeField]
    private List<GameObject> chunksList = new List<GameObject>();

    private float timer = 0.0f;
    private bool _paused = false;

    public int spawnTimer = 4;

    private void Update()
    {
        if (!_paused) {
            timer += Time.deltaTime;
            if ((int)timer % spawnTimer == 0) {
                ChunkSpawn();
                timer++;
            }
        }

        if(chunksList.Count > 5) {
            Destroy(chunksList[0]);
            chunksList.RemoveAt(0);
        }
    }

    private void ChunkSpawn()
    { 
        chunksList.Add(Instantiate(
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

    public bool IsPaused()
    {
        return _paused;
    }
}
