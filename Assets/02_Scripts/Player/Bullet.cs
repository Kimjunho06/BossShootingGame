using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private float _randomFire;
    

    public GameObject _bullet;

    private void Start()
    {
        StartCoroutine("FireDelay");
    }

    IEnumerator FireDelay()
    {
        while (true)
        {
            _randomFire = Random.Range(0, 1f);
            Instantiate(_bullet, transform.position, Quaternion.identity);
            yield return new WaitForSeconds(_randomFire);
        }
    }
    
    IEnumerator DestroyDelay()
    {
        while (true)
        {
            yield return new WaitForSeconds(2f);
            Destroy(_bullet);
        }
    }
}
