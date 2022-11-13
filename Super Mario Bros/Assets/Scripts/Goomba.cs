using UnityEngine;

public class Goomba : MonoBehaviour
{
    public Sprite flatSprite;//ссылка на спрайт (для изменения)

    private void OnCollisionEnter2D(Collision2D collision)//ф-ция для обнаружения столкновения с игроком
    {
        if(collision.gameObject.CompareTag("Player"))//проверяем с кем столкнулся
        {
            if(collision.transform.DotTest(transform, Vector2.down)){
                Flatten();
            }   
        }
    }
    private void Flatten()
    {
        GetComponent<Collider2D>().enabled = false;
        GetComponent<EntityMovement>().enabled = false;
        GetComponent<AnimatedSprite>().enabled = false;
        GetComponent<SpriteRenderer>().sprite = flatSprite; 
        Destroy(gameObject, 0.5f); 
    }
}