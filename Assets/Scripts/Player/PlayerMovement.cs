using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Adjustable Variables
    [Header("Adjustable Variables")]
    [Space]
    [SerializeField] float moveSpeed;
    [SerializeField] private ParticleSystem[] underGroundRocks;


    //Components
    private bl_Joystick joystick;
    private Animator animator;
    private GroundState groundState;

    private Vector3 joystickAxis;

    
    

    // Start is called before the first frame update
    void Start()
    {
        groundState = GetComponent<GroundState>();
        
        animator = GetComponent<Animator>();
        joystick = FindObjectOfType<bl_Joystick>();
    }

    // Update is called once per frame
    void Update()
    {
        joystickAxis = joystick.inputVector;

        float xAxis = joystickAxis.x * moveSpeed * Time.deltaTime;
        float zAxis = joystickAxis.z * moveSpeed * Time.deltaTime;

        if(groundState.GetGroundState() == GroundState.PlayersGroundState.BelowGround)
        {
            transform.position += new Vector3(xAxis, 0, zAxis);
            
        }
        
        

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (groundState.GetGroundState() == GroundState.PlayersGroundState.AboveGround)
            {
                animator.SetTrigger("GoUnderGround");
                groundState.ChangeState();
            }
            else if (groundState.GetGroundState() == GroundState.PlayersGroundState.BelowGround)
            {
                animator.SetTrigger("GoAboveGround");
                groundState.ChangeState();
            }
            
            
        }
    }
}
