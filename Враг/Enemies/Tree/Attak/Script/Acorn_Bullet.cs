using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 10f;
    public int damage = 10;
    private Vector2 direction;
    private Rigidbody2D rb;

    // Враг вызовет этот метод сразу после создания пули
    public void Setup(Vector2 shootDirection)
    {
        direction = shootDirection.normalized;

        // Уничтожаем пулю через 3 секунды, чтобы не засорять сцену
        Destroy(gameObject, 3f);
    }

    void Update()
    {
        transform.position += (Vector3)direction * speed * Time.deltaTime;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // Если попали в игрока
        if (other.CompareTag("Player"))
        {
            // Здесь можно нанести урон
            Destroy(gameObject);
        }
        // Если попали в стену (не триггер и не игрок)
        else if (!other.isTrigger)
        {
            Destroy(gameObject);
        }
    }
}