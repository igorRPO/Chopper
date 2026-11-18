using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Hero))]
public class Movement : MonoBehaviour
{
    private Rigidbody2D rb;
    private Hero hero;
    private Vector2 moveInput;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        hero = GetComponent<Hero>();

        rb.freezeRotation = true;
        rb.gravityScale = 0f;
    }

    private void Update()
    {
        moveInput.x = Input.GetAxisRaw("Horizontal");
        moveInput.y = Input.GetAxisRaw("Vertical");

        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            hero.Attack();
        }
    }

    private void FixedUpdate()
    {
        Vector2 movement = moveInput.normalized * hero.speed;
        rb.linearVelocity = movement;
    }
}
