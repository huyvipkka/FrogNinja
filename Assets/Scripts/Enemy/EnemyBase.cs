using UnityEngine;

public abstract class EnemyBase : MonoBehaviour
{
    protected Rigidbody2D rb;
    protected CharState EnemyState = CharState.RUN;
    protected float enemySpeed = 3;
    protected virtual void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = Vector2.left * GameManager.Instance.speed;
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        EnemyMove();
        DestroyByDis();
    }

    protected virtual void EnemyMove()
    {
        transform.position += (GameManager.Instance.speed + enemySpeed) * Time.deltaTime * Vector3.left;
    }

    protected virtual void DestroyByDis()
    {
        if (transform.position.x < -20)
        {
            Destroy(gameObject);
        }
    }
}