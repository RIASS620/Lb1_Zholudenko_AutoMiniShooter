using System.Collections.Generic;
using UnityEngine;

// Розміщується на об'єкті, який створює інші об'єкти (наприклад, на зброї або спавнері ворогів)
public class ObjectPool : MonoBehaviour
{
    [SerializeField] private GameObject prefab;
    [SerializeField] private int initialPoolSize = 10;

    private Queue<GameObject> pool = new Queue<GameObject>();

    private void Start()
    {
        for (int i = 0; i < initialPoolSize; i++)
        {
            CreateNewObject();
        }
    }

    private GameObject CreateNewObject()
    {
        GameObject obj = Instantiate(prefab, transform);
        obj.SetActive(false);

        // Додаємо компонент, щоб об'єкт знав, куди повертатися
        PoolMember member = obj.GetComponent<PoolMember>() ?? obj.AddComponent<PoolMember>();
        member.Initialize(this);

        pool.Enqueue(obj);
        return obj;
    }

    public GameObject GetObject()
    {
        GameObject obj = pool.Count > 0 ? pool.Dequeue() : CreateNewObject();
        obj.SetActive(true);
        obj.transform.SetParent(null); // Відкріплюємо від пулу під час гри
        return obj;
    }

    public void ReturnObject(GameObject obj)
    {
        obj.SetActive(false);
        obj.transform.SetParent(transform);
        pool.Enqueue(obj);
    }
}