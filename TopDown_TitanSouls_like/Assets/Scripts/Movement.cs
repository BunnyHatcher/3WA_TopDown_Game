using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    //Components to be referenced
    private Rigidbody2D _rb2d;
    private Animator _animator;
    
    //Vectors for movement and orientation
    private Vector2 _direction;
    private Vector2 _orientation;

    //the different movement speeds
    public float _runSpeed = 10f;
    public float _rollSpeed = 5f;
    public float _sprintSpeed = 15f;
    
    //speed currently effective
    public float _currentSpeed;

    //Bool to check if player has controls at the moment
    public bool _isControllable = true;

    // bool to check if player is rolling
    public bool _isRolling = false;
    
    // floats for calculating cooldown delay between two rolls
    [SerializeField]
    private float _rollDuration = 0.5f; // duration of roll in sec
    private float _timeRollFinish = 0; // timer after the end of the roll




    void Start()
    {
        // set up Rigidbody for use in the script
        _rb2d = GetComponent<Rigidbody2D>();
        // get the Animator as a child of the PlayerRig where we planted our script
        _animator = GetComponentInChildren<Animator>();
    }


    void Update() //receive input for movement
    {
        if (_isControllable)

        {
            _direction = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

            // check with magnitude (=length of vector3), if player is moving or not
            if (_direction.magnitude > 0) //if magnitude is above 0, the player is moving
            {
                // use animators for the corresponding movement direction
                _animator.SetFloat("SpeedX", _direction.x);
                _animator.SetFloat("SpeedY", _direction.y);
                _animator.SetBool("isMoving", true);

                // clamp orientation
                _orientation = Vector2.ClampMagnitude(_direction * 10000f, 1f);

                // trigger roll
                if(Input.GetButtonDown("Jump"))
                {

                    _isRolling = true;
                    _animator.SetBool("isRolling", true);

                    //calculate roll timer: add time passed to time until roll is finished
                    _timeRollFinish =_rollDuration + Time.timeSinceLevelLoad;
                    
                }
                
                bool rollFinish = Time.timeSinceLevelLoad > _timeRollFinish;

                if (!Input.GetButtonDown("Jump") && rollFinish)
                {
                    _isRolling = false;
                    _animator.SetBool("isRolling", false);
                }

            }

            else //if magnitude is below 0, the player is not moving
            {
                // use animators for the corresponding idle direction
                _animator.SetFloat("SpeedX", _orientation.x);
                _animator.SetFloat("SpeedY", _orientation.y);
                _animator.SetBool("isMoving", false);

            }

        }

    }
        private void FixedUpdate() //transform movement input into actual movement
        {
            _rb2d.velocity = _direction.normalized * _runSpeed;

        }
}
