using UnityEngine;
using UnityEngine.Pool;

public abstract class EnemyPool<T> : MonoBehaviour where T : MonoBehaviour
{
    [SerializeField] protected T prefab;
    public ObjectPool<T> pool;
    protected void Awake()
    {
        pool = new ObjectPool<T>(CreateFunc,
                ActionOnGet, ActionOnRelease, ActionOnDestroy,
                collectionCheck: true, defaultCapacity: 100, maxSize: 1000);
    }
    protected T CreateFunc()
    {
        T obj = Instantiate(prefab);
        return obj;
    }

    protected void ActionOnGet(T obj)
    {
        obj.gameObject.SetActive(true);
    }

    protected void ActionOnRelease(T obj)
    {
        obj.gameObject.SetActive(false);
    }

    protected void ActionOnDestroy(T obj)
    {
        Destroy(obj);
    }
}