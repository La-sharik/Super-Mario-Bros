using System.Collections;
using UnityEngine;

public class BlockItem : MonoBehaviour
{
    private void Start()
    {
        StartCoroutine(Animate());
    }

    private IEnumerator Animate()
    {
        Rigidbody2D rigidBody = GetComponent<Rigidbody2D>();
        BoxCollider2D triggerCollider = GetComponent<BoxCollider2D>();
        CircleCollider2D physicsCollider = GetComponent<CircleCollider2D>();
        SpriteRenderer spriteRender = GetComponent<SpriteRenderer>();

        rigidBody.isKinematic = true;//тело ставновиться без физики
        //отключаем другие коллайдеры
        triggerCollider.enabled = false;
        physicsCollider.enabled = false;
        spriteRender.enabled = false;

       yield return new WaitForSeconds(0.25f);

        spriteRender.enabled = true;
        
        float elapsed = 0f;
        float duration = 0.5f;

        Vector3 startPosition = transform.localPosition;
        Vector3 endPosition = transform.localPosition + Vector3.up;

        while(elapsed < duration)
        {
            float t = elapsed/duration;

            transform.position = Vector3.Lerp(startPosition, endPosition, t);
            elapsed += Time.deltaTime;

            yield return null;
        }
        triggerCollider.enabled = true;
        physicsCollider.enabled = true;
        rigidBody.isKinematic = false;
    }
}
