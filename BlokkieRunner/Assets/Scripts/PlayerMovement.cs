using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    [SerializeField]
    private float _moveSpeed = 6f;
    [SerializeField]
    private float _jumpSpeed = 6f;

    private bool _grounded = false, _dead = false, _paused = false, _idle = true;
    private int _score = 0;

    private Rigidbody rb;
    private Vector3 velocity;

    private Vector3 savedVelocity;
    private Vector3 savedAngularVelocity;

   
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.isKinematic = true;
    }

    private void Update()
    {
        GroundCheck();

        if(_idle)
            velocity = Vector3.right * _moveSpeed;

        if (!_idle && Input.GetButtonDown("Jump")) {
            Jump();
        }
    }

    private void FixedUpdate()
    {
        if (!_paused)
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

    public bool IsGrounded()
    {
        return _grounded;
    }

    public void Jump()
    {
        if(rb.velocity.y < 0)
            rb.AddForce(new Vector3(0, Mathf.Abs(rb.velocity.y / 2), 0), ForceMode.Impulse);

        rb.AddForce(new Vector3(0, _jumpSpeed, 0), ForceMode.Impulse);
    }

    public void Pause()
    {
        savedVelocity = rb.velocity;
        savedAngularVelocity = rb.angularVelocity;
        rb.isKinematic = true;
        _paused = true;
    }

    public void Resume()
    {
        rb.isKinematic = false;
        rb.AddForce(savedVelocity, ForceMode.Impulse);
        rb.AddTorque(savedAngularVelocity, ForceMode.Impulse);
        _paused = false;
    }

    public void SetIdle(bool idle)
    {
        if (idle)
            rb.isKinematic = false;
        else if (idle)
            rb.isKinematic = true;
    }

    public bool IsIdle()
    {
        return _idle;
    }

    public bool IsPaused()
    {
        return _paused;
    }

    public int GetScore()
    {
        return _score;
    }
}
