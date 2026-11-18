using System.Collections;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    public Transform player;
    private bool isActive = false;
    private bool isActive_Attack = false;

    public GameObject bulletPrefab; // Сюда перетащите префаб пули
    public Transform firePoint;     // Сюда перетащите FirePoint

    private Specifications stats;

    void Start() // ссылаемся к характеристикам
    {
        stats = GetComponent<Specifications>();
    }

    public void StartPatrol(Transform player_Transform)
    {
        if (!isActive)
        {
            StopAllCoroutines();
            isActive = true;
            isActive_Attack = false;
            player = player_Transform;
            StartCoroutine(PatrolLoop());
        }
    }

    IEnumerator PatrolLoop() // перемещение
    {
        while (isActive)
        {
            if (player != null)
            {
                float diffX = player.position.x - transform.position.x;
                float direction = Mathf.Sign(diffX);
                transform.position += new Vector3(direction * stats.speed * Time.deltaTime, 0, 0);
                yield return null;
            }
            else
            {
                isActive = false;
                break;
            }
        }
    }

    public void Start_attack(Transform player_Transform)
    {
        StopAllCoroutines();
        isActive = false;
        isActive_Attack = true;
        player = player_Transform;
        StartCoroutine(AttackLoop());
    }

    IEnumerator AttackLoop() // в радиусе аттаки
    {
        while (isActive_Attack)
        {
            // Проверяем, что всё привязано в Инспекторе
            if (bulletPrefab != null && firePoint != null && player != null)
            {
                // Создаем пулю в координатах FirePoint
                GameObject newBullet = Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);

                // Считаем направление
                Vector2 shootDirection = (player.position - firePoint.position).normalized;

                // Передаем направление пуле
                newBullet.GetComponent<Bullet>().Setup(shootDirection);
            }
            else
            {
                Debug.LogError("ОШИБКА: Не привязан Bullet Prefab или Fire Point в Инспекторе!");
            }

            yield return new WaitForSeconds(stats.attackCooldown);
        }
    }

    public void End() // ратерял игрока
    {
        StopAllCoroutines();
        isActive = false;
        isActive_Attack = false;
    }
}