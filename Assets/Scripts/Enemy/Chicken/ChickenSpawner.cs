public class ChickenSpawner : EnemyPool<EnemyChicken>
{
    public static ChickenSpawner Instance { get; private set; }
    protected new void Awake()
    {
        if (Instance != null && Instance != this)
            Destroy(gameObject);
        else Instance = this;

        base.Awake();
    }
    protected new void ActionOnGet(EnemyChicken obj)
    {
        obj.ResetPos(transform.position);
        base.ActionOnGet(obj);
    }
}