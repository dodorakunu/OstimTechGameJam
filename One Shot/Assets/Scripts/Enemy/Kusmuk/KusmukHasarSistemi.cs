using UnityEngine;

public class KusmukHasarSistemi : MonoBehaviour
{
    private PlayerHealthSystem playerHealth;
    private GameObject player;

    void Start()
    {
        player = GameObject.FindWithTag("Player"); // Player tag'li GameObject'i bulur
        if (player != null)
        {
            playerHealth = player.GetComponent<PlayerHealthSystem>();
        }
        else
        {
            Debug.LogError("Player tag'li GameObject bulunamad�!");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && playerHealth != null)
        {
            if(playerHealth.posioned == true)
            {
                playerHealth.damageMult *= 2f;
            }
            playerHealth.posioned = true;
        }
    }
}
