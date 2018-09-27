using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChunkSpawnerScript : MonoBehaviour {

    [SerializeField]
    private GameObject[] chunks;
    [SerializeField]
    private GameObject obj;

    void Start()
    {
        Debug.Log(obj);
        GameObject gameObj = Instantiate(chunks[Random.Range(0, chunks.Length - 1)], obj.transform.position, obj.transform.rotation);
    }
}
