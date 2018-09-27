using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowObject : MonoBehaviour {

    [SerializeField]
    private GameObject obj;

    public Vector3 offset;

    void FixedUpdate()
    {
        Vector3 pos = obj.transform.position;
        this.transform.position = pos + offset;
    }
}
