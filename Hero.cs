using UnityEngine;

public class Hero : MonoBehaviour
{
    [Header("Stats")]
    public float maxHP = 100f;
    public float currentHP;
    public float damage = 10f;
    public float speed = 5f;

    [Header("Attack")]
    public float attackRange = 1.5f;
    public float attackCooldown = 0.5f;
    private float nextAttackTime;

    private void Awake()
    {
        currentHP = maxHP;
    }

    public void Attack()
    {
        if (Time.time < nextAttackTime) return;

        nextAttackTime = Time.time + attackCooldown;

        Collider2D[] hits = Physics2D.OverlapCircleAll(transform.position, attackRange);
        foreach (var hit in hits)
        {
            if (hit.gameObject == gameObject) continue;

            Hero target = hit.GetComponent<Hero>();
            if (target != null)
            {
                target.TakeDamage(damage);
            }
        }
    }

    public void TakeDamage(float amount)
    {
        currentHP -= amount;

        if (currentHP <= 0f)
        {
            Die();
        }
    }

    public void Heal(float amount)
    {
        currentHP = Mathf.Min(currentHP + amount, maxHP);
    }

    public bool IsAlive => currentHP > 0f;

    private void Die()
    {
        gameObject.SetActive(false);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCircle(transform.position, attackRange);
    }
}
