using UnityEngine;

public class DefaultZombie : MonoBehaviour
{
    public float zombieHealth = 100f;
    public float zombieDamage = 10f;
    public float zombieSpeed;
    public GameObject player;

    private Transform playerTransform;

    public PlayerController playerController;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GameObject playerObj = GameObject.FindGameObjectWithTag("Player");
        if (playerObj != null)
        {
            playerTransform = playerObj.transform;
        }

        playerController = player.GetComponent<PlayerController>();
        zombieSpeed = playerController.moveSpeed * 0.8f;
    }

    // Update is called once per framey
    void Update()
    {
        if (player != null)
        {
            // Hedef yöne doðru ilerle
            Vector2 direction = (playerTransform.position - transform.position).normalized;
            transform.position += (Vector3)(direction * zombieSpeed * Time.deltaTime);
        }
        

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerHealthSystem playerHealthSystem = collision.gameObject.GetComponent<PlayerHealthSystem>();
            playerHealthSystem.posioned = true;
            playerHealthSystem.SubtractTime(zombieDamage);
        }
    }

}
