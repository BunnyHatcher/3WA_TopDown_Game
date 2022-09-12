using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private Rigidbody2D _rb2d;
    private Animator _animator;
    private Vector2 _direction;

   [SerializeField] private float _moveSpeed = 10f;


    // Start is called before the first frame update
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

        _animator.SetFloat("SpeedX", _direction.x);
        _animator.SetFloat("SpeedY", _rb2d.velocity.y);

    }

    private void FixedUpdate() //transform movement input into actual movement
    {
        _rb2d.velocity = _direction.normalized * _moveSpeed;

    }
}
