using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBullet : MonoBehaviour
{
    
    [SerializeField] private GameObject _player;

    [SerializeField] private float _bulletSpeed = 1f;

    Vector3 _bulletDir;

    private void Start()
    {
        _player = GameObject.Find("Player");
        _bulletDir = _player.transform.position - gameObject.transform.position;

    }

    private void Update()
    {
        Move();

    }
    

    private void Move()
    {
        transform.Translate(_bulletDir * _bulletSpeed * Time.deltaTime);
    }
}
