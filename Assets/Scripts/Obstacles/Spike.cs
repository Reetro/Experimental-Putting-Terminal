using UnityEngine;

public class Spike : MonoBehaviour
{
    public float damageAmount = 1;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            var health = collision.gameObject.GetComponent<HealthComponent>();

            health.ApplyDamage(damageAmount);

            Destroy(gameObject);
        }
    }
}
