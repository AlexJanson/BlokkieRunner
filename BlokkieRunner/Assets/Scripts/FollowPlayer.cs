using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour {

    [SerializeField]
    private GameObject player;

    public Vector3 offset;

    void FixedUpdate()
    {
        
        Vector3 pos = transform.position;
        pos.x = player.transform.position.x;
        transform.position = new Vector3(pos.x + offset.x, offset.y, offset.z);
    }
}
