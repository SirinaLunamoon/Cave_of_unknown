using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private Rigidbody2D _rb2d;
    private Animator _animator;
    private Vector2 _movement;
    private string _animationState = "AnimationState";

    [SerializeField] private float _moveSpeed = 1.0f;

    enum MovementStates
    { 
        walkRight = 1, 
        walkLeft = 2,
        walkUp = 3, 
        walkDown = 4
    }

    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
        if (_animator == null)
        {
            Debug.Log(message: "Player is missing Animator!");
        }

        _rb2d = GetComponent<Rigidbody2D>();
        if (_rb2d == null)
        {
            Debug.Log(message: "Player is missing Rigidbody 2D!");
        }
    }

    private void Update()
    {
        UpdateState();
    }

    private void FixedUpdate()
    {
        MoveCharacter();
    }

    void MoveCharacter()
    {
        _movement.x = Input.GetAxisRaw("Horizontal");
        _movement.y = Input.GetAxisRaw("Vertical");

        //Normalize a vector and sprite will move with the same amount of speed in all directions.
        _movement.Normalize();

        //A Player object velocity with an assign of rigidbody and move it.
        _rb2d.velocity = _movement * _moveSpeed;
    }

    private void UpdateState()
    {
        if (_movement.x > 0)
        {
            _animator.SetInteger(_animationState, (int)MovementStates.walkRight);
        }
        else if (_movement.x < 0)
        {
            _animator.SetInteger(_animationState, (int)MovementStates.walkLeft);
        }

        else if (_movement.y > 0)
        {
            _animator.SetInteger(_animationState, (int)MovementStates.walkUp);
        }
        else if (_movement.y < 0)
        {
            _animator.SetInteger(_animationState, (int)MovementStates.walkDown);
        }
    }
}
