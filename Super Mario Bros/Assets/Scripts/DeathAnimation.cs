using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathAnimation : MonoBehaviour
{
    public Sprite deathSprite;
    public SpriteRenderer spriteRenderer;

    private void Reset()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnEnable()
    {
        UpdateSprite();
        DisablePhysics();
        StartCoroutine(Animate()); //Используем подпрограмму, чтобы сделать для каждого кадра анимацию совместной

    }

    private void UpdateSprite()
    {
        spriteRenderer.enabled = true; //Включение анимации
        spriteRenderer.sortingOrder = 9; //Вынос игрока поверх всего
        if (deathSprite != null) {
            spriteRenderer.sprite = deathSprite;
        }
    }

    private void DisablePhysics()
    {
        Collider2D[] colliders = GetComponents<Collider2D>();
        foreach (Collider2D collider in colliders) {
            collider.enabled = false; //Отключение коллайдеров для падения
        }
        GetComponent<Rigidbody2D>().isKinematic = true; //Отключение движка
        PlayerMovement playerMovement = GetComponent<PlayerMovement>(); //Отключение скрипта игрока
        if (playerMovement != null) {
            playerMovement.enabled = false;
        }
        /*EntityMovement entityMovement = GetComponent<EntityMovement>(); //Отключение скрипта врага
        if (entityMovement != null) {
            entityMovement.enabled = false;
        }*/
    }

    private IEnumerator Animate()
    {
        float elapsed = 0f;
        float duration = 3f;
        float jumpVelocity = 10f;
        float gravity = -40f;

        Vector3 velocity = Vector3.up * jumpVelocity;
        while (elapsed < duration) {
            transform.position += velocity * Time.deltaTime;
            velocity.y += gravity * Time.deltaTime;
            elapsed += Time.deltaTime;
            yield return null; //Возврат каждого кадра
        }
    }
}
