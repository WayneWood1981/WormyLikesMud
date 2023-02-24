using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Rigidbody2D), typeof(CircleCollider2D))]
public class PlayerMovement : MonoBehaviour
{

    [SerializeField] private Rigidbody2D _rigidBody2D;
    [SerializeField] private FixedJoystick _joystick;
    [SerializeField] private Animator _animator;
    private CircleCollider2D _circleColl;

    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _jumpForce = 10;
    [SerializeField] private float _jumpHeight = 5;
    [SerializeField] private float _gravityScale = 5;
    [SerializeField] private float _fallGravityScale = 15;
    private bool _isJumping = false;

    private bool _isGrounded = false;

    public LayerMask ignoreMask; 

    // Start is called before the first frame update
    void Start()
    {
        _circleColl = GetComponent<CircleCollider2D>();   
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && _isGrounded)
        {
            _rigidBody2D.gravityScale = _gravityScale;
            _jumpForce = Mathf.Sqrt(_jumpHeight * (Physics2D.gravity.y * _rigidBody2D.gravityScale) * -2) * _rigidBody2D.mass;
            _isJumping = true;
            _isGrounded = false;
            
        }

        // Turn Player In Direction
        if(_joystick.Horizontal != 0)
        {
            if(_joystick.Horizontal > 0)
            {
                transform.localScale = new Vector3(-0.5f, 0.5f, 0.5f);
            }
            else if(_joystick.Horizontal < 0)
            {
                transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
            }
        }

        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(_joystick.Horizontal > 0)
        {
            
            _rigidBody2D.AddForce(Vector2.right * _moveSpeed, ForceMode2D.Force);
        }
        else if (_joystick.Horizontal < 0)
        {
            
            _rigidBody2D.AddForce(-Vector2.right * _moveSpeed, ForceMode2D.Force);
        }


        if (_isGrounded)
        {
            _rigidBody2D.gravityScale = _gravityScale;
            
        }
        else
        {
            _rigidBody2D.gravityScale = _fallGravityScale;
           
        }

        
        
        if(_isJumping == true)
        {
            _rigidBody2D.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);
            _isJumping = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Ground")
        {
            _isGrounded = true;
        }
    }

}
