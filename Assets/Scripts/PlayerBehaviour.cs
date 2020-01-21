using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    private Vector3 _touchPosition;
    private Vector3 _touchDirection;
    private Transform _playerTransform;
    private Rigidbody2D _playerRB;
    private BoxCollider2D _playerBounds;
    private float _nextFire;
    private float minX, maxX;
    private bool _isDead = false;

    public float Speed = 1;
    public GameObject Bullet;
    public float fireRate;
    public LivesParameter  LivesParameter;
    public LivesManager LivesManager;
    public GameObject dieParticle;

    private void Start()
    {
        _playerTransform = GetComponent<Transform>();
        _playerRB = GetComponent<Rigidbody2D>();
        _playerBounds = GetComponent<BoxCollider2D>();


        minX = CameraExtensions.OrthographicBounds(Camera.main).min.x + _playerBounds.bounds.size.x;
        maxX = CameraExtensions.OrthographicBounds(Camera.main).max.x - _playerBounds.bounds.size.x;
        _isDead = false;
    }

    private void FixedUpdate()
    {
       // _playerTransform.Translate(new Vector3(Input.acceleration.x, 0f, 0f));

        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            _touchPosition = Camera.main.ScreenToWorldPoint(touch.position);
            _touchPosition.z = 0;
            _touchPosition.y = _playerTransform.position.y;
            _touchDirection = (_touchPosition - _playerTransform.position);
            _playerRB.velocity = new Vector2(_touchDirection.x, _touchDirection.y) * Speed;
            if (touch.phase == TouchPhase.Ended)
                _playerRB.velocity = Vector2.zero;
        }

        //if (Input.GetKey(KeyCode.A))
        //    _playerRB.velocity = new Vector2(-Speed, 0);
        //else if (Input.GetKey(KeyCode.D))
        //    _playerRB.velocity = new Vector2(Speed, 0);
        //else
        //    _playerRB.velocity = Vector2.zero;

        if (Time.time > _nextFire)
        {
            Instantiate(Bullet,_playerTransform.position, Quaternion.identity);
            _nextFire = Time.time + fireRate;
        }
    }

    private void LateUpdate()
    {
        var newPosition = _playerTransform.position;
        newPosition.x = Mathf.Clamp(newPosition.x,minX,maxX);
        _playerTransform.position = newPosition;
    }

    private void PlayerHit()
    {
        if(!_isDead)
        {
            GameObject explode =  Instantiate(dieParticle, _playerTransform.position,Quaternion.identity);
            Destroy(explode, 0.2f);

            _isDead = true;
            LivesManager.RemoveALife();
            //explode particle
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            Debug.Log("Player has been hit");
            PlayerHit();
        }
    }
}
