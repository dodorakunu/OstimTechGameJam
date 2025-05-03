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
            Debug.LogError("Player tag'li GameObject bulunamadý!");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && playerHealth != null)
        {
            Debug.Log("posion");
            playerHealth.posioned = true;
            if (playerHealth.posioned)
            {
                playerHealth.currentTime -= 10f;
            }
        }
    }
}
