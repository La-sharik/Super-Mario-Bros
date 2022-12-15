using UnityEngine;

public class PowerUp : MonoBehaviour
{
    private GameObject player;
    public AudioClip audioClip;
    private AudioSource audioSource;

    public enum Type
    {
        Coin,
        ExtraLife,
        Mushrooms,
        Starpower,
    }
    public Type type;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) {
            Collect(other.gameObject);
        }
    }

    private void Collect(GameObject player) 
    {
        audioSource = player.GetComponent<AudioSource>();
        switch (type)
        {
            case Type.Coin:
                GameManager.Instance.AddCoin();
                break;

            case Type.ExtraLife:
                GameManager.Instance.AddLives();
                audioSource.PlayOneShot(audioClip);
                break;

            case Type.Mushrooms:
                GameManager.Instance.AddMushroom();
                audioSource.PlayOneShot(audioClip);
                player.GetComponent<Player>().Grow();
                break;

            case Type.Starpower:
                GameManager.Instance.AddStar();
                audioSource.PlayOneShot(audioClip);
                player.GetComponent<Player>().Starpower();
                break;
        }
    Destroy(gameObject);
    }

}
