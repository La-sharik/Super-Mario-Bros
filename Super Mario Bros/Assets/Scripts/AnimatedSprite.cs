using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatedSprite : MonoBehaviour
{
    public Sprite[] sprites;
    public float framerate = 1f / 6f;

    private SpriteRenderer spriteRenderer;
    private int frame; //Индекс спрайта

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnEnable() //Во время работы
    {
        InvokeRepeating(nameof(Animate), framerate, framerate); //Вызов функции "Animate" многократно, с периодом framerate
    }

    private void OnDisable() //Когда выключен
    {
        CancelInvoke(); //Прекращение повторения
    }
    
    private void Animate() //Смена спрайта
    {
        frame++;
        if (frame >= sprites.Length){
            frame = 0; //Установка начального спрайта
        }
        if (frame >=0 && frame <= sprites.Length) {
            spriteRenderer.sprite = sprites[frame]; //Установка спрайта
        }
    }
}
