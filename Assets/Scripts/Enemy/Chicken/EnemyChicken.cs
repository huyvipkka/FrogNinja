public class EnemyChicken : EnemyBase
{
    protected override void DestroyByDis()
    {
        ChickenSpawner.Instance.pool.Release(this);
    }
}