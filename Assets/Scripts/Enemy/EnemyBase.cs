using UnityEngine;
public abstract class EnemyBase : MonoBehaviour
{
    public Rigidbody2D rb;
    [SerializeField] protected float enemySpeed = 3;
    protected GameManager gameManager = GameManager.Instance;

    protected virtual void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = Vector2.left * gameManager.speed;
    }

    protected virtual void Update()
    {
        EnemyMove();
        DestroyByDis();
    }
    protected virtual void FixedUpdate() { }

    protected virtual void EnemyMove()
    {
        rb.transform.position += (gameManager.speed + enemySpeed) * Time.deltaTime * Vector3.left;
    }

    public virtual void ResetPos(Vector3 newPos)
    {
        rb.transform.position = newPos;
    }
    protected abstract void DestroyByDis();
}