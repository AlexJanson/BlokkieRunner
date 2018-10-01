using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    [SerializeField]
    private float moveSpeed = 6f;
    [SerializeField]
    private float jumpSpeed = 6f;

    private bool _grounded = false, _jumped = false, _dead = false;
    private int _score = 0;

    private Rigidbody rb;
    private Vector3 velocity;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        velocity = Vector3.right * moveSpeed;

        GroundCheck();

        if(_dead) {
            Time.timeScale = 0;
        }
    }

    private void FixedUpdate()
    {
        if (Input.GetButtonDown("Jump")) {
            rb.AddForce(new Vector3(0, jumpSpeed, 0), ForceMode.Impulse);
            _jumped = true;
        }

        rb.MovePosition(rb.position + velocity * Time.fixedDeltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Wall" || collision.gameObject.name == "SideWall_Bottom") {
            _dead = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "Triggered") {
            _score++;
        }
    }

    private void GroundCheck()
    {
        float DisstanceToTheGround = GetComponent<Collider>().bounds.extents.y;
        _grounded = Physics.Raycast(transform.position, Vector3.down, DisstanceToTheGround + 0.1f);
    }

    public bool IsDead()
    {
        return _dead;
    }
}
