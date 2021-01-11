using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 0f;
    private float _dirX;
    private float _dirY;
    [SerializeField] private float rotationSpeed = 0.5f;
    [SerializeField] private Rigidbody2D rb;
    public Vector2 direction;
    
    private void Update()
    {
        _dirX = CrossPlatformInputManager.GetAxisRaw("Horizontal");
        _dirY = CrossPlatformInputManager.GetAxisRaw("Vertical");
        direction = new Vector2(_dirX, _dirY);
        
        if (_dirX != 0 || _dirY != 0)
        {
            var dirZ = Mathf.Atan2(_dirX, _dirY) * Mathf.Rad2Deg;
            //transform.eulerAngles = new Vector3(0f, 0f, -dirZ);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(0,0, -dirZ), rotationSpeed);
            rb.velocity =  direction * moveSpeed;
        }
        else
        {
            rb.velocity = Vector2.zero;
        }
    }
}
