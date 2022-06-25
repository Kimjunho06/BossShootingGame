using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossPattern : MonoBehaviour
{

    [SerializeField] private GameObject _bossBulletBlack;
    [SerializeField] private GameObject _bossBulletWhite;


    public SpriteRenderer _spriteRenderer_black;
    public SpriteRenderer _spriteRenderer_white;
    public SpriteRenderer _spriteRenderer_bullet;


    public bool _isBulletChange = false;


    private void Awake()
    {
        _spriteRenderer_black = GameObject.Find("DarkBall").GetComponent<SpriteRenderer>();
        _spriteRenderer_white = GameObject.Find("Ball").GetComponent<SpriteRenderer>();
        _spriteRenderer_bullet = _bossBulletBlack.GetComponent<SpriteRenderer>();
        

    }

    private void Start()
    {
        StartCoroutine("ChangeDelay");
        StartCoroutine(FireDelayBlack(0.5f));
        
    }


    private void Update()
    {
        

        //if (_isBulletChange == false)
        //{
        //    _spriteRenderer_bullet.sprite = _spriteRenderer_black.sprite;

        //}
        //if (_isBulletChange == true)
        //{
        //    _spriteRenderer_bullet.sprite = _spriteRenderer_white.sprite;
        //}
    }


    IEnumerator FireDelayBlack(float sec)
    {
        while (true)
        {
            if(_isBulletChange == false)
            {
                GameObject a = PoolManager.Instance.Pop(_bossBulletBlack);
                a.transform.position = gameObject.transform.position;
                yield return new WaitForSeconds(sec);
            }
            if(_isBulletChange == true)
            {
                GameObject a = PoolManager.Instance.Pop(_bossBulletWhite);
                a.transform.position = gameObject.transform.position;
                yield return new WaitForSeconds(sec);
            }

        }
    }

    //IEnumerator FireDelayWhite()
    //{
    //    while (true)
    //    {
    //        Instantiate(_bossBulletWhite, transform.position, Quaternion.identity);
    //        yield return new WaitForSeconds(0.5f);
    //    }
    //}

    IEnumerator ChangeDelay()
    {
        while (true)
        {
            _isBulletChange = true;
            yield return new WaitForSeconds(3f);
            _isBulletChange = false;
            yield return new WaitForSeconds(3f);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject != gameObject)
        {
            PoolManager.Instance.Push(collision.gameObject);
        }
    }

   

    


}
