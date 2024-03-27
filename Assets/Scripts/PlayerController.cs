using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Vector3 _moveVector;
    private CharacterController _characterController;

    public Animator _animator;

    public float gravity = 9.8f;

    private float _fallVelocity = 0;
    public float JumpForce;
    public float Speed;


    // Start is called before the first frame update
    void Start()
    {
        _characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    private void Update()
    {
        MovementUpdate();

        DanceUpdate();

        JumpUpdate();
    }

    private void DanceUpdate()
    {
        if(Input.GetKey(KeyCode.Z))
        {
            _animator.SetTrigger("dance");
        }
    }

    private void MovementUpdate()
    {
        _moveVector = Vector3.zero;
        var runDirection = 0;



        if (Input.GetKey(KeyCode.W))
        {
            _moveVector += transform.forward;
            runDirection = 1;
        }

        if (Input.GetKey(KeyCode.S))
        {
            _moveVector -= transform.forward;
            runDirection = 2;
        }

        if (Input.GetKey(KeyCode.D))
        {
            _moveVector += transform.right;
            runDirection = 3;
        }

        if (Input.GetKey(KeyCode.A))
        {
            _moveVector -= transform.right;
            runDirection = 4;
        }

        _animator.SetInteger("run direction", runDirection);
    }

    private void JumpUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Space) && _characterController.isGrounded)
        {
            _fallVelocity = -JumpForce;
        }
    }

    void FixedUpdate()
    {
        //Movement
        _characterController.Move(_moveVector * Speed * Time.fixedDeltaTime);

        //Fall and Jump
        _fallVelocity += gravity * Time.fixedDeltaTime;
        _characterController.Move(Vector3.down *  _fallVelocity * Time.fixedDeltaTime);

        //Stop fall if on the ground
        if(_characterController.isGrounded)
        {
            _fallVelocity = 0;
        }
    }
}
