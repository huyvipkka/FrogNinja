using UnityEngine;

public class Bunny : EnemyBase
{
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
        if (!isDie)
        {
            AutoJump();
            UpdateStateAndAnimation();
        }
    }

    private void AutoJump()
    {
        jumpTimer += Time.deltaTime;
        if (jumpTimer < jumpRaze) return;
        jumpTimer = 0;

        jumpRaze = Random.Range(1f, 3f);
        rb.AddForce(Vector2.up * 20, ForceMode2D.Impulse);
    }

    private void UpdateStateAndAnimation()
    {
        if (rb.velocity.y < 0)
            enemyState = CharState.FALL;
        else if (rb.velocity.y > 0)
            enemyState = CharState.JUMP;
        else
            enemyState = CharState.RUN;

        ani.SetInteger("State", (int)enemyState);
    }
}
