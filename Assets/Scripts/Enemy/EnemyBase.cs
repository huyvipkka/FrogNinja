using UnityEngine;

public abstract class EnemyBase : MonoBehaviour
{
    protected Rigidbody2D rg;
    protected CharState EnemyState = CharState.RUN;
    protected float enemySpeed = 3;
    protected virtual void Start()
    {
        rg = GetComponent<Rigidbody2D>();
        rg.velocity = Vector2.left * GameManager.instance.speed;
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        EnemyMove();
        DestroyByDis();
    }

    protected virtual void EnemyMove()
    {
        transform.position += (GameManager.instance.speed + enemySpeed) * Time.deltaTime * Vector3.left;
    }

    protected virtual void DestroyByDis()
    {
        if (transform.position.x < -20)
        {
            Destroy(gameObject);
        }
    }
}