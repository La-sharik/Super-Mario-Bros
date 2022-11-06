using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 8f;
    public float maxJumpHeihgt = 5f;
    public float maxJumpTime = 2f;
    public float jumpForce => (2f * maxJumpHeihgt) / (maxJumpTime / 2f);
    public float gravity => (-2f * maxJumpHeihgt) / Mathf.Pow((maxJumpTime / 2f), 2);
     public bool grounded {get; private set; } //Переменная "На земле"
    public bool jumping {get; private set; } //Переменная "Прыжок"
    public bool running => (Mathf.Abs(velocity.x) > 0.25f) || (Mathf.Abs(inputAxis) > 0.25f); //Переменная "Бег"
    public bool sliding => (velocity.x > 0f && inputAxis < 0f) || (velocity.x < 0f && inputAxis > 0f); //Переменная "Скольжение"

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
        velocity.x = Mathf.MoveTowards(velocity.x, inputAxis * moveSpeed, moveSpeed * Time.deltaTime * 2);
        if(rigidbody.Raycast(Vector2.right * velocity.x))
        {
            velocity.x = 0f;
        }
        if (velocity.x > 0f) { //Поворот
            transform.eulerAngles = Vector3.zero;
        } else if (velocity.x < 0) {
            transform.eulerAngles = new Vector3 (0f, 180f, 0f);
        }
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

//  сталкновение с блоком сверху если столкнулись сверху с блоком то скорость по Oy обнуляем, чтобы сразу начал падать
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.layer != LayerMask.NameToLayer("PowerUp") && transform.DotTest(collision.transform, Vector2.up))
        {
            velocity.y = 0f;
        }
    }
}
