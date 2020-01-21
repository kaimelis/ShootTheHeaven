using UnityEngine;

public class BulletBehaviour : MonoBehaviour
{
    private Transform _transform;
    public float Speed = 1;
    public ScoreParameter Score;

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
        if(other.CompareTag("Enemy"))
        {
            if(other.gameObject != null)
            {
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
