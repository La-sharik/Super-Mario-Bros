using System.Collections;
using UnityEngine;

public class BlockCoin : MonoBehaviour
{
    private GameObject player;
    public AudioClip audioClip;
    private AudioSource audioSource;

    private void Start()
    {
        GameManager.Instance.AddCoin();
        player = GameObject.FindGameObjectWithTag("Player");
        audioSource = player.GetComponent<AudioSource>();

        StartCoroutine(Animate());
    }

    private IEnumerator Animate()
    {
        Vector3 restingPosition = transform.localPosition;//начальная позиция блока
        Vector3 animatePosition = restingPosition + Vector3.up * 2.5f;

        audioSource.PlayOneShot(audioClip);
        
        yield return Move(restingPosition, animatePosition);
        yield return Move(animatePosition, restingPosition);

        Destroy(gameObject); 
    }

        private IEnumerator Move(Vector3 from, Vector3 to)
    {
        float elapsed = 0f;//сколько времени прошло с начала движения
        float duration = 0.5f;//сколько длиться анимация

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
