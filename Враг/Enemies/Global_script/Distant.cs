using UnityEngine;

public class Distant : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
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

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            EnemyPatrol myPatrol = GetComponentInParent<EnemyPatrol>();

            if (myPatrol != null)
            {
                myPatrol.End();
            }
        }
    }
}
        
