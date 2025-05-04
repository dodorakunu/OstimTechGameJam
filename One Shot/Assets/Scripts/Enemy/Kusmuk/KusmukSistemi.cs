using UnityEngine;

public class KusmukSistemi : MonoBehaviour
{
    public float lifeTime = 5f;

    void Start()
    {
        Destroy(gameObject, lifeTime);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Oyuncunun health sistemine zarar ver
            PlayerHealthSystem pt = other.GetComponent<PlayerHealthSystem>();
            Destroy(gameObject);
        }
        else if (other.gameObject.layer == LayerMask.NameToLayer("Obstacle"))
        {
            Destroy(gameObject); // Duvara çarparsa yok olsun
        }
    }
}
