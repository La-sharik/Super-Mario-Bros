using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public PlayerSpriteRenderer smallRenderer;
    public PlayerSpriteRenderer bigRenderer;
    public DeathAnimation deathAnimation;
    public bool small => smallRenderer.enabled;
    public bool big => bigRenderer.enabled;
    public bool dead => deathAnimation.enabled;
    
    public void Awake()
    {
        deathAnimation = GetComponent<DeathAnimation>();
    }

    public void Hit()
    {
        if (big) {
            Shrink();
        } else {
            Death();
        }
    }

    public void Shrink() //Уменьшение размера
    {
        // In progress
    }

    public void Death()
    {
        smallRenderer.enabled = false; //Отключение рендеринга
        bigRenderer.enabled = false; //Отключение рендеринга
        deathAnimation.enabled = true; //Включение анимации смерти
        GameManager.Instance.ResetLevel(3f); //Перезагрузка уровня через 3 секунды
    }
}
