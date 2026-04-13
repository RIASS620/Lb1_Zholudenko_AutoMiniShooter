using UnityEngine;

// Вішається на префаби (снаряди, вороги). Дозволяє об'єкту самостійно повернутися в правильний пул.
public class PoolMember : MonoBehaviour
{
    private ObjectPool myPool;

    public void Initialize(ObjectPool pool)
    {
        myPool = pool;
    }

    public void ReturnToPool()
    {
        if (myPool != null)
            myPool.ReturnObject(gameObject);
        else
            Destroy(gameObject); // Фолбек, якщо пулу немає
    }
}