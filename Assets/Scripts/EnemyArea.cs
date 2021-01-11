using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyArea : MonoBehaviour
{
    [HideInInspector]
    public bool TargetInRange;
    [SerializeField] private string targetTagName; 

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(targetTagName))
        {
            TargetInRange = true;
        }
    }


    private void OnTriggerExit2D(Collider2D collision)
    {
        TargetInRange = false;
    }
}
