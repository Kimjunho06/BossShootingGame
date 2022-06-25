using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPop : MonoBehaviour
{
    [SerializeField] GameObject _bullet;

    [SerializeField] private float _bulletFire= 2f;

    private void Start()
    {
        StartCoroutine(PlayerBulletSpawn());
    }

    IEnumerator PlayerBulletSpawn()
    {
        while (true)
        {
            GameObject a = PoolManager.Instance.Pop(_bullet);
            a.transform.position = transform.position;
            yield return new WaitForSeconds(_bulletFire);
        }
    }
}
