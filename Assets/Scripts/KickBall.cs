using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KickBall : MonoBehaviour
{
    [SerializeField] private GameObject ball;
    [SerializeField] private GameObject gatePoint;
    [SerializeField] private float speed;

    private Rigidbody2D _ballRb;

    private bool _moveBall;
    private bool _goal;

    private void Start()
    {
        _ballRb = ball.GetComponent<Rigidbody2D>();
    }

    public void Kick()
    {
            //_ballRb.AddForce(_gatePoint.transform.position * _speed, ForceMode2D.Impulse);
        _moveBall = true;
       
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Kick();
        }
    }

    private void Update()
    {
        if (_moveBall)
        {
            ball.transform.SetParent(null);

            ball.transform.position = Vector3.MoveTowards(ball.transform.position, gatePoint.transform.position, speed);
            if (Vector2.Distance(ball.transform.position, gatePoint.transform.position) < 0.01)
            {
                _ballRb.velocity = Vector3.zero;
                _moveBall = false;
                _goal = true;
            }
        }
    }
}
