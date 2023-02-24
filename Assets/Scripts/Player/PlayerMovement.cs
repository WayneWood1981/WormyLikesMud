using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class PlayerMovement : MonoBehaviour
{

    [SerializeField] private CharacterController cc;
    [SerializeField] private FixedJoystick _joystick;
    [SerializeField] private Animator _animator;

    private float gravity = -9.81f;
    [SerializeField] private float gravityModifier;
    private CapsuleCollider2D _cc;

    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _jumpForce = 10;
    [SerializeField] private float _jumpHeight = 5;
    [SerializeField] private float _gravityScale = 5;
    [SerializeField] private float _fallGravityScale = 15;

    ConstantForce2D constantForce;

    private bool _isJumping = false;

    private bool _isGrounded = false;

    public LayerMask ignoreMask; 

    // Start is called before the first frame update
    void Start()
    {
        _cc = GetComponent<CapsuleCollider2D>();
        constantForce = GetComponent<ConstantForce2D>();
    }

    private void Update()
    {
        float _move = _moveSpeed * Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.Space) && cc.isGrounded)
        {
            
            _isJumping = true;
            _isGrounded = false;
            
        }

        float horizontalAxis = _joystick.Horizontal;

        

        // Turn Player In Direction
        if(_joystick.Horizontal != 0)
        {
            
            if(_joystick.Horizontal > 0)
            {
                
                transform.localScale = new Vector3(-0.5f, 0.5f, 0.5f);
                cc.Move(Vector3.right * _moveSpeed);

            }
            else if(_joystick.Horizontal < 0)
            {
                transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
                cc.Move(-Vector3.right * _moveSpeed);
            }
        }
        

    }


}
