using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossPattern : MonoBehaviour
{
    [SerializeField] private GameObject _bossBullet;

    private void Awake()
    {

    }

    private void Start()
    {
        StartCoroutine("FireDelay");
    }


    private void Update()
    {
        
    }


    IEnumerator FireDelay()
    {
        while (true)
        {
            Instantiate(_bossBullet, transform.position, Quaternion.identity);
            yield return new WaitForSeconds(0.5f);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject != gameObject)
        {
            Destroy(collision.gameObject);
        }
    }
}
