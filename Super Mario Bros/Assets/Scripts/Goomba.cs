using UnityEngine;

public class Goomba : MonoBehaviour
{
    public Sprite flatSprite;//ссылка на спрайт (для изменения)

    private void OnCollisionEnter2D(Collision2D collision)//ф-ция для обнаружения столкновения с игроком
    {
        if(collision.gameObject.CompareTag("Player"))//проверяем с кем столкнулся
        {
            Player player = collision.gameObject.GetComponent<Player>();

            if(player.starpower){
                Hit();
            } else if(collision.transform.DotTest(transform, Vector2.down)){
                Flatten();
            } else {
                player.Hit();
            }   
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
         if(other.gameObject.layer == LayerMask.NameToLayer("Shell"))
         {
            Hit();
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
    
    private void Hit()
    {
        GetComponent<AnimatedSprite>().enabled = false;//выключаем анимацию движения 
        GetComponent<DeathAnimation>().enabled = true;//включаем скрипт про смерть
        Destroy(gameObject, 3f);//разрушаем объект
    }
}
