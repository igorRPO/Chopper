using UnityEngine;

public class Attack : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            EnemyPatrol myPatrol = GetComponentInParent<EnemyPatrol>();

            if (myPatrol != null)
            {
                myPatrol.Start_attack(other.transform);
            }
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            EnemyPatrol myPatrol = GetComponentInParent<EnemyPatrol>();

            if (myPatrol != null)
            {
                myPatrol.StartPatrol(other.transform);
            }
        }
    }
}
