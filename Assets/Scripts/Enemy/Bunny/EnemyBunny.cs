using UnityEngine;

public class EnemyBunny : EnemyBase
{
    protected Animator ani;
    [SerializeField] protected CharState EnemyState = CharState.IDLE;

    [SerializeField] protected float jumpRaze = 2;
    [SerializeField] protected float jumpTimer = 0;
    protected override void Start()
    {
        base.Start();
        ani = GetComponent<Animator>();
    }

    protected override void Update()
    {
        base.Update();
        AutoJump();
        UpdateStateAndAnimation();
    }
    private void AutoJump()
    {
        jumpTimer += Time.deltaTime;
        if (jumpTimer < jumpRaze) return;
        jumpTimer = 0;

        jumpRaze = Random.Range(1f, 3f);
        rb.velocity = Vector2.up * 10;
    }

    private void UpdateStateAndAnimation()
    {
        if (rb.velocity.y < 0)
            EnemyState = CharState.FALL;
        else if (rb.velocity.y > 0)
            EnemyState = CharState.JUMP;
        else
            EnemyState = CharState.RUN;

        ani.SetInteger("State", (int)EnemyState);
    }

    protected override void DestroyByDis()
    {
        BunnySpawner.Instance.pool.Release(this);
    }
}