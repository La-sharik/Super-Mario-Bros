using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpriteRenderer : MonoBehaviour
{
    public Sprite idle;
    public Sprite jump;
    public Sprite slide;
    public AnimatedSprite run; //Объект анимироанного спрайта

    public SpriteRenderer spriteRenderer { get; private set;}
    private PlayerMovement movement;

    private void OnEnable() //Обработка спрайта
    {
        spriteRenderer.enabled = true;
    }

    private void OnDisable()
    {
        spriteRenderer.enabled = false;
    }

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        movement = GetComponentInParent<PlayerMovement>();
    }
    private void LateUpdate()
    {
        run.enabled = movement.running; //Включение или выклчение анимации бега

        if (movement.jumping) { // Выбор спрайта
            spriteRenderer.sprite = jump;
        } else if (movement.sliding) {
            spriteRenderer.sprite = slide;
        } else if (!movement.running) {
            spriteRenderer.sprite = idle;
        }
    }
}
