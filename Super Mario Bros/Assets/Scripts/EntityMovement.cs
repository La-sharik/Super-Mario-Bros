using UnityEngine;

public class EntityMovement : MonoBehaviour
{
    public float speed = 1f;
    public Vector2 direction = Vector2.left;//так как все враги начинают двигаться влево
    public float gravity = -9.81f;

    private new Rigidbody2D rigidbody;
    private Vector2 velocity;

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        enabled = false; 
    }
    private void OnBecameVisible()
    {
        enabled = true;
    }
    private void OnBecameInvisible()
    {
        enabled  = false;
    }
    private void OnEnable()
    {
        rigidbody.WakeUp();
    }
    private void OnDisable()
    {
        rigidbody.velocity = Vector2.zero;
        rigidbody.Sleep();
    }
    private void FixedUpdate()
    {
        velocity.x = direction.x * speed;
        velocity.y += gravity * Time.fixedDeltaTime;

        rigidbody.MovePosition(rigidbody.position + velocity* Time.fixedDeltaTime); 

        if(rigidbody.Raycast(direction)){//если столкнулся со стенкой. Повернется в обратную сторону
            direction = -direction;
        }

        if(rigidbody.Raycast(Vector2.down)){//если заземлен то скорость по y не увеличивается 
            velocity.y = Mathf.Max(velocity.y, 0f);
        }
    }
}
