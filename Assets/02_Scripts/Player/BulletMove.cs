using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMove : MonoBehaviour
{
    [SerializeField] private float _MoveSpeed;
    [SerializeField] Vector3 Movedirection = Vector3.zero;



    private void Update()
    {
        transform.position += Movedirection * _MoveSpeed * Time.deltaTime;
        BulletPush();
    }

    public void MoveTo(Vector3 direction)
    {
        Movedirection = direction;
    }

    private void BulletPush()
    {
        if (gameObject.transform.position.x >= 13)
        {
            PoolManager.Instance.Push(gameObject);
        }
    }
}
