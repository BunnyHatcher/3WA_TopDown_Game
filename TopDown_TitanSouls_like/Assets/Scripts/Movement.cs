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

    [SerializeField] private float _moveSpeed = 10f;


    
    void Start()
    {
        // set up Rigidbody for use in the script
        _rb2d = GetComponent<Rigidbody2D>();
        // get the Animator as a child of the PlayerRig where we planted our script
        _animator = GetComponentInChildren<Animator>();
    }


    void Update() //receive input for movement
    {
        _direction = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

        // check with magnitude (=length of vector3), if player is moving or not
        if (_direction.magnitude > 0) //if magnitude is above 0, the player is moving
        {
            // use animators for the corresponding movement direction
            _animator.SetFloat("SpeedX", _direction.x);
            _animator.SetFloat("SpeedY", _direction.y);
            _animator.SetBool("isMoving", true);

            // clamp
            _orientation = Vector2.ClampMagnitude(_direction * 10000f, 1f);
        }

        else //if magnitude is below 0, the player is not moving
        {
            // use animators for the corresponding idle direction
            _animator.SetFloat("SpeedX", _orientation.x);
            _animator.SetFloat("SpeedY", _orientation.y);
            _animator.SetBool("isMoving", false);

        }

    }
        private void FixedUpdate() //transform movement input into actual movement
        {
            _rb2d.velocity = _direction.normalized * _moveSpeed;

        }
}
