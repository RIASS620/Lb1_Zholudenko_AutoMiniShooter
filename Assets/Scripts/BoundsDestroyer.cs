using UnityEngine;

public class BoundsDestroyer : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out PoolMember member))
            member.ReturnToPool();
        else
            collision.gameObject.SetActive(false);
    }
}