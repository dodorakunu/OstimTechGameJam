using UnityEngine;

public class RunnerZombieController : MonoBehaviour
{
    public float zombieDamage = 10f;
    public float zombieSpeed;
    public float turnSpeed = 180f; 
    public ZombiesHealthSystem ZombiesHealthSystem;

    public GameObject player;

    private Transform playerTransform;

    public PlayerController playerController;
  
    void Start()
    {
        ZombiesHealthSystem = GetComponent<ZombiesHealthSystem>();
        ZombiesHealthSystem.Zombiehealth = 100f; //zombie can�

        GameObject playerObj = GameObject.FindGameObjectWithTag("Player");
        if (playerObj != null)
        {
            player = playerObj;
            playerTransform = playerObj.transform;
            playerController = player.GetComponent<PlayerController>();
            zombieSpeed = 7.5f; //zombie h�z�
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (player != null)
        {
            // Oyuncuya do�ru ilerle
            Vector2 direction = (playerTransform.position - transform.position).normalized;
            transform.position += (Vector3)(direction * zombieSpeed * Time.deltaTime);

            // Oyuncuya yava��a d�n
            Vector2 dirToPlayer = direction;
            float angleToPlayer = Mathf.Atan2(dirToPlayer.y, dirToPlayer.x) * Mathf.Rad2Deg;

            // Sprite'�n y�z� yukar� bak�yorsa -90 veya +90 ekle (burada +90 kullan�lm��)
            Quaternion targetRotation = Quaternion.Euler(0, 0, angleToPlayer + 90f);

            // Mevcut rotasyondan hedef rotasyona do�ru s�n�rl� d�n�� yap
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, turnSpeed * Time.deltaTime);
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
