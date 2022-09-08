using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private Rigidbody2D _rb2d;
    private Vector2 _direction;

   [SerializeField] private float _moveSpeed = 10f;


    // Start is called before the first frame update
    void Start()
    {
        _rb2d = GetComponent<Rigidbody2D>();
    }

    
    void Update() //receive input for movement
    {
        _direction = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
                
    }

    private void FixedUpdate() //transform movement input into actual movement
    {
        _rb2d.velocity = _direction.normalized * _moveSpeed;

    }
}
