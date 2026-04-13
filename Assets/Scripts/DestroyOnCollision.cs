using UnityEngine;

public class DestroyOnCollision : MonoBehaviour
{
    [SerializeField] private int damage = 1;
    [SerializeField] private string targetTag = "Enemy";
    [SerializeField] private bool destroySelfOnImpact = true;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(targetTag))
        {
            // Намагаємося знайти компонент Health на цілі
            Health targetHealth = collision.GetComponent<Health>();
            if (targetHealth != null)
            {
                targetHealth.TakeDamage(damage);
            }

            // Якщо це снаряд, він має зникнути після влучання
            if (destroySelfOnImpact)
            {
                ReturnSelf();
            }
        }
    }

    private void ReturnSelf()
    {
        PoolMember poolMember = GetComponent<PoolMember>();
        if (poolMember != null)
            poolMember.ReturnToPool();
        else
            gameObject.SetActive(false);
    }
}