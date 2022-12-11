using UnityEngine;

public class PowerUp : MonoBehaviour
{
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
        switch (type)
        {
            case Type.Coin:
                GameManager.Instance.AddCoin();
                break;

            case Type.ExtraLife:
                GameManager.Instance.AddLives();
                break;

            case Type.Mushrooms:
                GameManager.Instance.AddMushroom();
                player.GetComponent<Player>().Grow();
                break;

            case Type.Starpower:
                GameManager.Instance.AddStar();
                player.GetComponent<Player>().Starpower();
                break;
        }
    Destroy(gameObject);
    }

}
