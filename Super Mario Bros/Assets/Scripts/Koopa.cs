using UnityEngine;

public class Koopa : MonoBehaviour
{
    public Sprite shellSprite;//ссылка на спрайт (для изменения)
    private float shellSpeed = 12f;

    private bool shelled;//в каком состоянии находиться koopa
    private bool pushed;//если он в панцире то двигается или нет 

    private void OnCollisionEnter2D(Collision2D collision)//ф-ция для обнаружения столкновения с игроком
    {
        if (!shelled && collision.gameObject.CompareTag("Player"))//проверяем на столкновение с игроком
        {
            Player player = collision.gameObject.GetComponent<Player>();

            if(player.starpower){
                Hit();
            } else if (collision.transform.DotTest(transform, Vector2.down)) 
            {
                EnterShell();
            }  else 
            {
                player.Hit();
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (shelled && other.CompareTag("Player"))//проверяем с кем столкнулся
        {
            if (!pushed)
            {
                Vector2 direction = new Vector2(transform.position.x - other.transform.position.x, 0f);
                PushShell(direction);
            }
            else
            {
                Player player = other.GetComponent<Player>();

                if(player.starpower){
                    Hit();
                } else  {
                    player.Hit();
                }
            }
        }
        else if (!shelled && other.gameObject.layer == LayerMask.NameToLayer("Shell"))
        {
            Hit();
        }
    }
    private void EnterShell()
    {
        shelled = true;

        GetComponent<SpriteRenderer>().sprite = shellSprite;
        GetComponent<AnimatedSprite>().enabled = false;
        GetComponent<EntityMovement>().enabled = false;
    }

    private void PushShell(Vector2 direction)
    {
        pushed = true;

        GetComponent<Rigidbody2D>().isKinematic = false;

        EntityMovement movement = GetComponent<EntityMovement>();
        movement.direction = direction.normalized;
        movement.speed = shellSpeed;
        movement.enabled = true;

        gameObject.layer = LayerMask.NameToLayer("Shell");
    }

    private void Hit()
    {
        GetComponent<AnimatedSprite>().enabled = false;
        GetComponent<DeathAnimation>().enabled = true;
        Destroy(gameObject, 3f);
    }
}