using System.Collections;
using UnityEngine;
using UnityEngine.Pool;

public abstract class EnemyBase : MonoBehaviour
{
    protected Rigidbody2D rb;
    protected float enemySpeed = 3;
    protected CharState enemyState = CharState.RUN;
    public ObjectPool<EnemyBase> refPool;
    protected Animator ani;
    protected Collider2D colli;
    protected GameManager gameManager = GameManager.Instance;
    protected bool isDie = false;
    protected virtual void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        ani = GetComponent<Animator>();
        colli = GetComponent<Collider2D>();
        rb.velocity = Vector2.left * 4;
        rb.gravityScale = gameManager.gravityScale;
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        if (!isDie)
        {
            EnemyMove();
            DestroyByDis();
        }
    }

    protected virtual void EnemyMove()
    {
        transform.position += enemySpeed * Time.deltaTime * Vector3.left;
    }

    protected virtual void DestroyByDis()
    {
        if (transform.position.x < -20)
        {
            refPool.Release(this);
            isDie = true;
        }
    }

    public virtual void ResetNewEnemy(Vector3 pos)
    {
        isDie = false;
        GetComponent<Collider2D>().enabled = true;
        GetComponent<Rigidbody2D>().gravityScale = gameManager.gravityScale;
        transform.position = pos;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            isDie = true;
            rb.AddForce(new Vector2(3, 15), ForceMode2D.Impulse);
            rb.gravityScale = gameManager.gravityScale * 2;
            colli.enabled = false;

            ani.SetInteger("State", 4);
            StartCoroutine(ReleaseObjectAfterDelay(1f));
        }
    }

    private IEnumerator ReleaseObjectAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        refPool.Release(this);
    }
}