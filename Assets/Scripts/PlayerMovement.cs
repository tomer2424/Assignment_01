using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;

    [SerializeField] private float moveSpeed = 8.0f;
    private Vector2 movementVector;
    private bool facingRight = true;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        HandleCamera();
        HandleMovement();
        HandleFlip();
    }

    private void FixedUpdate()
    {   
        rb.MovePosition(rb.position + movementVector * moveSpeed * Time.fixedDeltaTime);
    }

    private void HandleMovement()
    {
        movementVector.x = GetHorizontalAxis();
        movementVector.y = GetVerticalAxis();

        if (movementVector.sqrMagnitude > 1.0f)
        {
            movementVector.Normalize();
        }
    }

    private float GetHorizontalAxis()
    {
        bool right = Keyboard.current.dKey.isPressed;
        bool left = Keyboard.current.aKey.isPressed;
        
        if (left == right)
        {
            return 0f;
        }

        return (right ? 1.0f : -1.0f);
    }

    private float GetVerticalAxis()
    {
        bool up = Keyboard.current.wKey.isPressed;
        bool down = Keyboard.current.sKey.isPressed;

        if (up == down)
        {
            return 0f;
        }

        return (up ? 1.0f : -1.0f);
    }

    private void HandleFlip()
    {
        if (Keyboard.current.dKey.isPressed && !facingRight)
        {
            Flip();
        }
        else if (Keyboard.current.aKey.isPressed && facingRight)
        {
            Flip();
        }
    }
    private void Flip()
    {
        facingRight = !facingRight;
        gameObject.transform.Rotate(0f, 180.0f, 0f);
    }

    private void HandleCamera()
    {
        Camera.main.transform.position = new Vector3(transform.position.x, transform.position.y, -10.0f);
    }
} 
