using UnityEngine;
using UnityEngine.Pool;

public abstract class EnemyBase : MonoBehaviour
{
    protected Rigidbody2D rb;
    protected float enemySpeed = 3;
    public ObjectPool<GameObject> refPool;
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
            refPool.Release(gameObject);
        }
    }

    public virtual void ResetPos(Vector3 pos)
    {
        transform.position = pos;
    }
}