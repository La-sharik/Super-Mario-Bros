using System.Collections;
using UnityEngine;

public class HitBlock : MonoBehaviour
{
    public GameObject item;//вещь которая будет появлсять из mystery block(coin, star, ..)
    public int maxHits = -1;//бесконечное количество ударов выдерживает
    public Sprite emptyBlock;//это то чем станет блок после разрушения
    private bool animating;//нужна чтобы во время анимации не вызвалась еще одна анимация

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!animating && maxHits != 0 && collision.gameObject.CompareTag("Player"))
        {
            if (collision.transform.DotTest(transform, Vector2.up)) {
                Hit();
            }
        }
    }

    private void Hit()
    {
        SpriteRenderer spriteRender = GetComponent<SpriteRenderer>();
        // SpriteRenderer.enabled = true;//при ударе раскрывает скрытые 
        maxHits--;

        if (maxHits == 0) {
            spriteRender.sprite = emptyBlock;
        }

        if(item != null) {
            Instantiate(item, transform.position, Quaternion.identity);//создаем элемент
        }

        StartCoroutine(Animate());
    }

    private IEnumerator Animate()
    {
        animating = true;

        Vector3 restingPosition = transform.localPosition;//начальная позиция блока
        Vector3 animatePosition = restingPosition + Vector3.up * 0.5f;

        yield return Move(restingPosition, animatePosition);
        yield return Move(animatePosition, restingPosition);

        animating = false;
    }

        private IEnumerator Move(Vector3 from, Vector3 to)
    {
        float elapsed = 0f;//сколько времени прошло с начала движения
        float duration = 0.125f;//сколько длиться анимация

        while (elapsed < duration)
        {
            float t = elapsed / duration;

            transform.localPosition = Vector3.Lerp(from, to, t);
            elapsed += Time.deltaTime;

            yield return null;
        }

        transform.localPosition = to;
    }
}
