using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    private Transform _playerTransform;
    private Rigidbody2D _playerRB;
    public float Speed = 1;
    public GameObject Bullet;
    public float fireRate;
    private float _nextFire;

    private void Start()
    {
        _playerTransform = GetComponent<Transform>();
        _playerRB = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        // float moveH = Input.GetAxis("Horizontal");
        // _playerTransform.position += (Vector3.right * moveH * Speed);

        _playerTransform.Translate(new Vector3(Input.acceleration.x, 0f, 0f));

        if (_playerTransform.position.x > -5.925f && Input.GetKey(KeyCode.A))
            _playerRB.velocity = new Vector2(-Speed, 0);
        else if (_playerTransform.position.x < 5.925f && Input.GetKey(KeyCode.D))
            _playerRB.velocity = new Vector2(Speed, 0);
        else
            _playerRB.velocity = Vector2.zero;

        if (Time.time > _nextFire)
        {
            Instantiate(Bullet,_playerTransform.position, _playerTransform.rotation);
            _nextFire = Time.time + fireRate;
        }
    }
}
