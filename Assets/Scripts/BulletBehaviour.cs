using UnityEngine;

public class BulletBehaviour : MonoBehaviour
{
    private Transform _transform;
    public float Speed = 1;
    public ScoreParameter Score;
    private EnemyManager enemyManager;
    public GameObject ExplosionParticle;

    void Start()
    {
        _transform = GetComponent<Transform>();
    }

    void FixedUpdate()
    {
        _transform.position += Vector3.up * Speed;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            if (other.gameObject != null)
            {
                enemyManager = other.gameObject.GetComponentInParent<EnemyManager>();
                enemyManager.RespawnEnemy();
                GameObject obj = Instantiate(ExplosionParticle, transform.position, Quaternion.identity);
                Destroy(obj, 0.2f);

#if !UNITY_EDITOR
                KyVibrator.Vibrate(1);
#endif
                Destroy(other.gameObject);
                Score.AddScore();
            }
            Destroy(gameObject);
        }
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
