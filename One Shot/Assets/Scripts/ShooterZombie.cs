using UnityEngine;
using UnityEngine.UIElements;

public class ShooterZombie : MonoBehaviour
{
    public Transform player;
    public GameObject projectilePrefab;
    public Transform firePoint;
    public float shootInterval = 2f;
    private float shootTimer;

    void Update()
    {
        if (player == null) return;
        firePoint.position = player.position;
    }

    void Shoot()
    {
        Vector2 direction = (firePoint.position - transform.position).normalized;
        Quaternion rotation = transform.rotation;
        GameObject projectile = Instantiate(projectilePrefab, transform.position, rotation);

        Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.linearVelocity = direction * 10f; // H�z burada ayarlan�yor
        }
    }

    public float escapeSpeed = 2f;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Vector2 dirToPlayer = (player.position - transform.position).normalized;
        float angleToPlayer = Mathf.Atan2(dirToPlayer.y, dirToPlayer.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, angleToPlayer + 90f);

        if (collision.CompareTag("Player"))
        {
            // Mermiyi fırlat
            Shoot();

            // Oyuncu çok yakınsa kaç
            float distance = Vector2.Distance(transform.position, player.position);
            if (distance <= 5f)
            {
                Debug.Log("Çok yakın! Kaçıyorum!");

                // Tam tersi yöne dön
                Vector2 oppositeDir = -dirToPlayer;
                float escapeAngle = Mathf.Atan2(oppositeDir.y, oppositeDir.x) * Mathf.Rad2Deg;
                transform.rotation = Quaternion.Euler(0, 0, escapeAngle);

                // Hareket etmeye başla
                rb.linearVelocity = oppositeDir * escapeSpeed;
            }
        }
    }

}
