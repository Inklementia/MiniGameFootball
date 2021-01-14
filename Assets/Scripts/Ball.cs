using System;
using UnityEngine;
using UnityEngine.Serialization;

public class Ball : MonoBehaviour
{
    /*public float speed;
    [SerializeField] private Vector2 end;
    private Vector2 start;

    [SerializeField] FixedJoint2D _fixedJoint;

    private void Start()
    {
        start = _fixedJoint.connectedAnchor;
        end = new Vector2(0, 1.5f);
    }

    private void Update()
    {
        //PingPong between 0 and 1
        
        float time = Mathf.PingPong(Time.time * speed, 1);
        _fixedJoint.connectedAnchor = Vector2.Lerp(start, end, time);
    }*/
    
    /*private float _speed = 2f;
    [SerializeField] private Transform initialPosition;
    
    private void Start()
    {
        Bounce(initialPosition.localPosition.y, initialPosition.localPosition.y + 0.2f);
    }
    
    private void Bounce(float from, float to)
    {
        initialPosition.DOLocalMoveY(to, _speed).OnComplete(() => Bounce(to, from));
        
    }*/
    
}
