using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    private Transform _transform;
    private Vector3 _direction;
    public float Speed = 1;
    private EnemyManager _enemyManager;
    public GameObject ExplosionParticle;
    void Start()
    {
        _transform = GetComponent<Transform>();
        _enemyManager = GetComponentInParent<EnemyManager>();

    }

    void FixedUpdate()
    {
        _transform.position += Vector3.down * Speed;

        if (_transform.position.y < CameraExtensions.OrthographicBounds(Camera.main).min.y)
            Destroy(gameObject);
    }

    private void OnDestroy()
    {
        if(_enemyManager != null)
        {
            _enemyManager.RespawnEnemy();
            GameObject obj = Instantiate(ExplosionParticle,transform.position,Quaternion.identity);
            Destroy(obj,0.2f);
            KyVibrator.Vibrate(1);
        }
    }
}
