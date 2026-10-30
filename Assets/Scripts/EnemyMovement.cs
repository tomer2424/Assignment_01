using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField] private Transform player;

    [SerializeField] private float moveSpeed = 5.0f;
    private bool facingRight = true;
    private float lastXPos;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        HandleRotate();
    }

    private void FixedUpdate()
    {
        rb.MovePosition(Vector2.MoveTowards(gameObject.transform.position, player.position, moveSpeed * Time.fixedDeltaTime));
    }

  
    private void HandleRotate()
    {
        if (facingRight && transform.position.x < lastXPos)
        {
            Flip();
        }
        else if (!facingRight && transform.position.x > lastXPos)
        {
            Flip();
        }

        lastXPos = transform.position.x;
    }

    private void Flip()
    {
        facingRight = !facingRight;
        gameObject.transform.Rotate(0f, 180.0f, 0f);
    }
}
