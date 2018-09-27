using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public float speed = 3.0f;
    public float sideSpeed = 6.0f;

    void FixedUpdate() {
        Vector2 pos = transform.position;
        pos.x += speed * Time.deltaTime;

        if (Input.GetKey("down")) {
            pos.y -= sideSpeed * Time.deltaTime;
        }

        if (Input.GetKey("up")) {
            pos.y += sideSpeed * Time.deltaTime;
        }

        transform.position = pos;
    }
}
