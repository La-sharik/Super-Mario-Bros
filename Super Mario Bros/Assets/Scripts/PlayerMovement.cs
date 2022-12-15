using UnityEngine;
using UnityEngine.InputSystem;

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
    public new Collider2D collider;

    private new Camera camera;
    private new Rigidbody2D rigidbody;
    private float inputAxis;
    private float jumpAxis;
    private Vector2 velocity;
    private GameObject player;
    public AudioClip audioClipJump;
    private AudioSource audioSource;
    public InputAction movement;

    private void Awake()
    {
        camera = Camera.main;
        rigidbody = GetComponent<Rigidbody2D>();
        collider = GetComponent<Collider2D>();
        player = GameObject.FindGameObjectWithTag("Player");
        audioSource = player.GetComponent<AudioSource>();
        
        movement.performed += OnMovementPerfomed;
        movement.canceled += OnMovementPerfomed;
    }

    private void OnMovementPerfomed(InputAction.CallbackContext context) {
        var direction = context.ReadValue<Vector2>();
        inputAxis = direction.x;
    }

    public void OnEnable()
    {
        rigidbody.isKinematic = false;
        collider.enabled = true;
        velocity = Vector2.zero;
        jumping = false;
        movement.Enable();
    }

    public void OnDisable()
    {
        rigidbody.isKinematic = true;
        collider.enabled = false;
        velocity = Vector2.zero;
        jumping = false; 
        movement.Disable();
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
        velocity.x = Mathf.MoveTowards(velocity.x, inputAxis * moveSpeed, moveSpeed * Time.deltaTime * 2);
        if(rigidbody.Raycast(Vector2.right * velocity.x))
        {
            velocity.x = 0f;
        }
        if (velocity.x > 0f) { //Поворот
            transform.eulerAngles = Vector3.zero;
        } else if (velocity.x < 0f) {
            transform.eulerAngles = new Vector3 (0f, 180f, 0f);
        } else if (velocity.x == 0f) {
            if (inputAxis > 0f) {
                transform.eulerAngles = Vector3.zero;
            } else if (inputAxis < 0f) {
                transform.eulerAngles = new Vector3 (0f, 180f, 0f);
            }
        }
    }

    private void GroundedMovement()
    {
        if (this.name == "Mario"){ 
            if (Input.GetKeyDown(KeyCode.W)){
                jumpAxis = 1;
            }
            if (Input.GetKeyUp(KeyCode.W)){
                jumpAxis = 0;
            }
        }
        if (this.name == "Luigi"){ 
            if (Input.GetKeyDown(KeyCode.UpArrow)){
                jumpAxis = 1;
            }
            if (Input.GetKeyUp(KeyCode.UpArrow)){
                jumpAxis = 0;
            }
        }

        velocity.y = Mathf.Max(velocity.y, 0f);
        jumping = velocity.y > 0f;

        if (jumpAxis == 1) {
            audioSource.PlayOneShot(audioClipJump);
            velocity.y = jumpForce;
            jumping = true;
        }
    }

    private void ApplyGravity()
    {
        if (this.name == "Mario"){ 
            if (Input.GetKeyDown(KeyCode.W)){
                jumpAxis = 1;
            }
            if (Input.GetKeyUp(KeyCode.W)){
                jumpAxis = 0;
            }
        }
        if (this.name == "Luigi"){ 
            if (Input.GetKeyDown(KeyCode.UpArrow)){
                jumpAxis = 1;
            }
            if (Input.GetKeyUp(KeyCode.UpArrow)){
                jumpAxis = 0;
            }
        }
        bool falling = velocity.y < 0f || jumpAxis != 1;
        float multiplier = falling ? 3f : 1f;
        velocity.y += gravity * multiplier * Time.deltaTime;
        velocity.y = Mathf.Max(velocity.y, gravity / 2f);
    }

//  сталкновение с блоком сверху если столкнулись сверху с блоком то скорость по Oy обнуляем, чтобы сразу начал падать
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.layer == LayerMask.NameToLayer("Enemy"))
        {
            if(transform.DotTest(collision.transform, Vector2.down)){
                velocity.y = jumpForce / 1.5f;
                jumping = true; 
            }
        }
        else if(collision.gameObject.layer != LayerMask.NameToLayer("PowerUp"))
        {
            if(transform.DotTest(collision.transform, Vector2.up))
                velocity.y = 0f;
        }
    }
}
