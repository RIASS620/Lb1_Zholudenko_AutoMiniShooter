using UnityEngine;

[RequireComponent(typeof(ObjectPool))]
public class ProjectileShooter : MonoBehaviour
{
    [SerializeField] private Transform firePoint;
    [SerializeField] private float fireRate = 0.5f; // Пострілів на секунду

    private ObjectPool projectilePool;
    private float fireTimer;

    private void Awake()
    {
        projectilePool = GetComponent<ObjectPool>();
    }

    private void Update()
    {
        fireTimer -= Time.deltaTime;

        if (fireTimer <= 0f)
        {
            Shoot();
            fireTimer = 1f / fireRate;
        }
    }

    private void Shoot()
    {
        GameObject projectile = projectilePool.GetObject();
        projectile.transform.position = firePoint != null ? firePoint.position : transform.position;
        projectile.transform.rotation = Quaternion.identity;
    }
}