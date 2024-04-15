public class BunnySpawner : EnemyPool<EnemyBunny>
{
    public static BunnySpawner Instance { get; private set; }
    protected new void Awake()
    {
        if (Instance != null && Instance != this)
            Destroy(gameObject);
        else Instance = this;

        base.Awake();
    }
    protected new void ActionOnGet(EnemyBunny obj)
    {
        obj.ResetPos(transform.position);
        base.ActionOnGet(obj);
    }
}