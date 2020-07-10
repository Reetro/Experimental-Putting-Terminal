using UnityEngine;
using UnityEngine.Events;

public class HealthComponent : MonoBehaviour
{
    [Header("Health Settings")]
    [Tooltip("The default health value the Gameobject has")]
    public float defaultHealth = 3f;

    public float currentHealth = 0f;
    private bool isDead = false;

    [System.Serializable]
    public class TakeAnyDamge : UnityEvent<float> { }

    [Header("Events")]
    [Space]
    public UnityEvent OnDeath;
    [Space]
    public TakeAnyDamge onTakeAnyDamage;

    void Start()
    {
        currentHealth = defaultHealth;
    }
    /// <summary>
    /// Remove from current health
    /// </summary>
    /// <param name="amount"></param>
    public void ApplyDamage(float amount)
    {
        currentHealth -= amount;

        onTakeAnyDamage.Invoke(amount);

        if (currentHealth <= 0)
        {
            isDead = true;

            OnDeath.Invoke();

            //TODO make better death system
            Destroy(gameObject);
        }
    }
    /// <summary>
    /// Get current health of the Gameobject
    /// </summary>
    public float GetCurrentHealth()
    {
        return currentHealth;
    }
    /// <summary>
    /// Check to see if the current Gameobject is dead
    /// </summary>
    /// <returns></returns>
    public bool GetIsDead()
    {
        return isDead;
    }
}
