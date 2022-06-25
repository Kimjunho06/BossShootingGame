using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] private float _playerSpeed = 5f;

    private void Update()
    {
        MovePlayer();
    }

    private void MovePlayer()
    {   //W A S D 이동 막기 위함
        if (Input.GetKey(KeyCode.RightArrow) && transform.position.x < 1f)
        {
            transform.position += Vector3.right * _playerSpeed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.LeftArrow) && transform.position.x > -11f)
        {
            transform.position += Vector3.left * _playerSpeed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.DownArrow) && transform.position.y > -3.4f)
        {
            transform.position += Vector3.down * _playerSpeed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.UpArrow) && transform.position.y < 5f)
        {
            transform.position += Vector3.up * _playerSpeed * Time.deltaTime;
        }
    }
}
