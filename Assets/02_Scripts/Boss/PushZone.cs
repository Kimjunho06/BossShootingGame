using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushZone : MonoBehaviour
{
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        PoolManager.Instance.Push(collision.gameObject);
    }

}
