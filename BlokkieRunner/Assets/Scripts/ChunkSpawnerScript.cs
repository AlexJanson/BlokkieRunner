using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChunkSpawnerScript : MonoBehaviour {

    [SerializeField]
    private GameObject[] chunks;
    [SerializeField]
    private GameObject obj;
    private float timer = 0.0f;

    public int spawnTimer = 4;

    void Update()
    {
        timer += Time.deltaTime;
        if((int)timer % spawnTimer == 0) {
            chunkSpawn();
            timer++;
        }
    }

    public void chunkSpawn()
    {
        GameObject gameObj = 
            Instantiate(
                chunks[Random.Range(0, chunks.Length)],
                this.transform.position,
                this.transform.rotation
            );
    }
}
