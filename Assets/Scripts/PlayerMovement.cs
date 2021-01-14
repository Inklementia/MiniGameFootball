using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 0f;
    [SerializeField] private float rotationSpeed = 0.5f;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Animator animator;
    public Vector2 direction;
    private float _dirX;
    private float _dirY;
    private Vector2 _currentVelocity;

    private float _ballSpeed;
    /*private void Start()
    {
        _ballSpeed = ball.speed;
    }*/

    private void Update()
    {
        _currentVelocity = rb.velocity;
        _dirX = CrossPlatformInputManager.GetAxisRaw("Horizontal");
        _dirY = CrossPlatformInputManager.GetAxisRaw("Vertical");
        direction = new Vector2(_dirX, _dirY);
             
        var dirZ = Mathf.Atan2(_dirX, _dirY) * Mathf.Rad2Deg;

        animator.SetFloat("xVelocity", Mathf.Abs(_currentVelocity.x));
        animator.SetFloat("yVelocity", Mathf.Abs(_currentVelocity.y));

        var dirZed = -dirZ;

        if (dirZed < 0)
        {
            dirZed += 360;
        }
        
        if (_dirX != 0 || _dirY != 0)
        {
            //ball.speed = _ballSpeed;

            if (Mathf.Abs(transform.localEulerAngles.z - dirZed) > 5)
            {
                animator.SetBool("canBounce", false);
            }
            else
            { 
                animator.SetBool("canBounce", true);
            }
            
            Debug.Log(Mathf.Abs(transform.localEulerAngles.z - dirZed));
            //transform.eulerAngles = new Vector3(0f, 0f, -dirZ);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(0,0, -dirZ), rotationSpeed);
            rb.velocity =  direction * moveSpeed;
    
            
        }
        else
        {
            animator.SetBool("canBounce", false);
            rb.velocity = Vector2.zero;
            //ball.speed = 0f;
            //Debug.Log(DOTween.KillAll());
        }
    }
}
