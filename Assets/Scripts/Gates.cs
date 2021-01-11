using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gates : MonoBehaviour
{
    private int _score;
    private bool _goal;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Ball")
        {
            _goal = true;
            _score += 1;
        }
        Debug.Log(_score);
    }
    
}
