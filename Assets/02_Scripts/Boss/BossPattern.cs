using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossPattern : MonoBehaviour
{
    public GameObject BossBullet;

    private void Start()
    {
        StartCoroutine("FireDelay");
    }
    
    IEnumerator FireDelay()
    {
        while (true)
        {
            Instantiate(BossBullet, transform.position, Quaternion.identity);
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
