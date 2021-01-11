using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    [SerializeField] private float speedBack;
    [SerializeField] private float speedTo;
    [SerializeField] private float stopRadius;

    [SerializeField] private Transform initialPos;

    [SerializeField] private GameObject target;

    private EnemyArea _enemyArea;
    

    private void Start()
    {
        _enemyArea = FindObjectOfType<EnemyArea>();
    }

    /*
    private bool CheckIfPlayerInRange()
    {
        return Vector2.Distance(transform.position, _playerPos.position) < _triggerRadius;
    }
    */

    private void Update()
    {
        var currentTargetPos = target.transform;

        if (_enemyArea.TargetInRange)
        {
            MoveToTarget(currentTargetPos);
        }
        else
        {
            MoveToInitialPos();
        }
    }

    /*
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            _goToPlayer = true;
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        _goToPlayer = false;
    }
    */
    private void MoveToTarget(Transform currentPos)
    {
        if (Vector2.Distance(transform.position, currentPos.position) > stopRadius)
        {
            float step = speedTo * Time.deltaTime; // calculate distance to move
            transform.position = Vector3.MoveTowards(transform.position, currentPos.transform.position, step);
        }
        else
        {
            target.transform.position = currentPos.position;

            Debug.Log("Lose");
        }
    }

    private void MoveToInitialPos()
    {

        float step = speedBack * Time.deltaTime; // calculate distance to move
        transform.position = Vector3.MoveTowards(transform.position, initialPos.position, step);

    }


    //gizmos

    private void OnDrawGizmos()
    {
        //Gizmos.DrawWireSphere(_initialPos.position, _triggerRadius);
        Gizmos.DrawWireSphere(transform.position, stopRadius);
    }
}