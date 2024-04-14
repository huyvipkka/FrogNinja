using UnityEngine;

public class EnemyBunny : EnemyBase
{
    protected Animator ani;
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

    float jumpRaze = 2;
    float jumpTimer = 0;
    private void AutoJump()
    {
        jumpTimer += Time.deltaTime;
        if (jumpTimer < jumpRaze) return;
        jumpTimer = 0;

        jumpRaze = Random.Range(1f, 3f);
        rg.velocity = Vector2.up * 10;
    }

    private void UpdateStateAndAnimation()
    {
        if (rg.velocity.y < 0)
            EnemyState = CharState.FALL;
        else if (rg.velocity.y > 0)
            EnemyState = CharState.JUMP;
        else
            EnemyState = CharState.RUN;

        ani.SetInteger("State", (int)EnemyState);
    }
}
