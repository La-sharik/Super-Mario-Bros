using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public PlayerSpriteRenderer smallRenderer;
    public PlayerSpriteRenderer bigRenderer;
    public DeathAnimation deathAnimation { get; private set; }
    public bool small => smallRenderer.enabled;
    public bool big => bigRenderer.enabled;
    
    private bool dead => deathAnimation.enabled;
    
    public void Awake()
    {
        deathAnimation = GetComponent<DeathAnimation>();
    }

    public void Hit()
    {
        if (big) {
            Shrink();
        } 
        if (small) {
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
