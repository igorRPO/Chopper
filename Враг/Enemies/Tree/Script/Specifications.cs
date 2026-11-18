using UnityEngine;

public class Specifications : MonoBehaviour
{
    public float speed = 2.0f; // скорасть передвижение

    public float attackCooldown = 5.0f; // перезорядка

    public int damage = 25; // урон

    public int maxHealth = 100; // ХП
    private int currentHealth;

    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;

        if (currentHealth <= 0) 
        {
            Die(); 
        }
    }

    private void Die() // при 0 ХП
    {
        Debug.Log("Враг побежден!");
        Destroy(gameObject);
    }
}
