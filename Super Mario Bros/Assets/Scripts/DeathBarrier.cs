using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DeathBarrier : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) //Если игрок
        {
            other.gameObject.SetActive(false); //Удаляет игрока
            GameManager.Instance.ResetLevel(3f); //Перезапуск игры через 3 секунды
        }
        else
        {
            Destroy(other.gameObject); //Удаляет ввсе остальное
        }
    }
}
