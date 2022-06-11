using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private float _randomFire;
    private float _fireSpeedMax = 2f;
    private float _fireSpeedMin = 1f;
    

    public GameObject _bullet;

    private void Start()
    {
        StartCoroutine("FireDelay");
    }

    IEnumerator FireDelay()
    {
        while (true)
        {
            _randomFire = Random.Range(_fireSpeedMin, _fireSpeedMax);
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
