using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 7f;
    public float maxJumpHeihgt = 5f;
    public float maxJumpTime = 2f;
    public float jumpForce => (2f * maxJumpHeihgt) / (maxJumpTime / 2f);
    public float gravity => (-2.35f * maxJumpHeihgt) / Mathf.Pow((maxJumpTime / 2f), 2);
    public bool grounded {get; private set; }
    public bool jumping {get; private set; }

    private new Camera camera;
    private new Rigidbody2D rigidbody;
    private float inputAxis;
    private Vector2 velocity;
    private void Awake()
    {
        camera = Camera.main;
        rigidbody = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        HorizontalMovement();
        grounded = rigidbody.Raycast(Vector2.down);
        if (grounded) {
            GroundedMovement();
        }

        ApplyGravity();
    }

    private void FixedUpdate()
    {
        Vector2 position = rigidbody.position;
        Vector2 leftEdge = camera.ScreenToWorldPoint(Vector2.zero);
        Vector2 rightEdge = camera.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
        
        position.x = Mathf.Clamp(position.x, leftEdge.x + 0.5f, rightEdge.x - 0.5f );
        position += velocity * Time.fixedDeltaTime;
        rigidbody.MovePosition(position);
    }

    private void HorizontalMovement()
    {
        inputAxis = Input.GetAxis("Horizontal");
        velocity.x = Mathf.MoveTowards(velocity.x, inputAxis * moveSpeed, moveSpeed * Time.deltaTime * 3);
    }

    private void GroundedMovement()
    {
        velocity.y = Mathf.Max(velocity.y, 0f);
        jumping = velocity.y > 0f;

        if (Input.GetButtonDown("Jump")) {
            velocity.y = jumpForce;
            jumping = true;
        }
    }

    private void ApplyGravity()
    {
        bool falling = velocity.y < 0f || !Input.GetButton("Jump");
        float multiplier = falling ? 3f : 1f;
        velocity.y += gravity * multiplier * Time.deltaTime;
        velocity.y = Mathf.Max(velocity.y, gravity / 2f);
    }
}