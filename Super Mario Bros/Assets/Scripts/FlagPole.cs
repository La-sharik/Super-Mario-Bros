using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlagPole : MonoBehaviour
{
    public Transform flag;
    public Transform poleBottom;
    public Transform castle;
    public float speed = 3f;
    public int nextWorld = 1;
    public int nexStage = 2;
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            StartCoroutine(MoveTo(flag, poleBottom.position)); //Опускание флага
            StartCoroutine(LevelComlpeteSequence(other.transform));
        }
    }

    private IEnumerator LevelComlpeteSequence(Transform player)
    {
        player.GetComponent<PlayerMovement>().enabled = false;

        yield return MoveTo(player, poleBottom.position); //Перемещение к основанию флага
        yield return MoveTo(player, player.position + Vector3.right);
        yield return MoveTo(player, player.position + Vector3.right + Vector3.down);
        yield return MoveTo(player, castle.position); //Перемещение к замку
        player.gameObject.SetActive(false);
        yield return new WaitForSeconds(2f);
        GameManager.Instance.LoadLevel(nextWorld, nexStage);
    }

    private IEnumerator MoveTo(Transform subject, Vector3 destinaton)
    {
        while (Vector3.Distance(subject.position, destinaton) > 0.1f)
        {
            subject.position = Vector3.MoveTowards(subject.position, destinaton, speed * Time.deltaTime);
            yield return null;
        }
        subject.position = destinaton;
    }
}
