using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class PlayerMovement : MonoBehaviour {

    [SerializeField]
    private float _moveSpeed = 6f;
    [SerializeField]
    private float _jumpSpeed = 6f;

    private bool _grounded = false, _dead = false, _paused = false, _idle = true;
    private int _score = 0;

    private Rigidbody _rb;
    private Vector3 _velocity;

    private Vector3 _savedVelocity;
    private Vector3 _savedAngularVelocity;

    private SpriteRenderer _spriteRenderer;

    public delegate void DeathDelegate();
    public event DeathDelegate deathEvent;
   
    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _rb.isKinematic = true;
    }

    private void Update()
    {
        GroundCheck();
         
        if(!_idle)
            _velocity = Vector3.right * _moveSpeed;

        if (!_idle && Input.GetButtonDown("Jump")) {
            Jump();
        }
    }

    private void FixedUpdate()
    {
        if (!_paused && !_idle)
            _rb.MovePosition(_rb.position + _velocity * Time.fixedDeltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Wall" || collision.gameObject.name == "SideWall_Bottom") {
            _dead = true;
            Die();
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
        if(_rb.velocity.y < 0)
            _rb.AddForce(new Vector3(0, Mathf.Abs(_rb.velocity.y / 2), 0), ForceMode.Impulse);

        _rb.AddForce(new Vector3(0, _jumpSpeed, 0), ForceMode.Impulse);
    }

    public void Pause()
    {
        _savedVelocity = _rb.velocity;
        _savedAngularVelocity = _rb.angularVelocity;
        _rb.isKinematic = true;
        _paused = true;
    }

    public void Resume()
    {
        _rb.isKinematic = false;
        _rb.AddForce(_savedVelocity, ForceMode.Impulse);
        _rb.AddTorque(_savedAngularVelocity, ForceMode.Impulse);
        _paused = false;
    }

    public void SetIdle(bool idle)
    {
        if (idle) {
            _idle = true;
            _rb.velocity = Vector3.zero;
            _rb.isKinematic = true;
        } else if (!idle) {
            _idle = false;
            _rb.isKinematic = false;
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

    public int GetScore()
    {
        return _score;
    }

    public void SetSprite(Sprite sprite)
    {
        _spriteRenderer.sprite = sprite;
    }

    public void Die()
    {
        if (deathEvent != null)
            deathEvent();
        //logic for the player
    }
}
